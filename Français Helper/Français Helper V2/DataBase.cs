using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;

namespace Français_Helper
{
    /// <summary>
    /// Encapsula todos los objetos de trabajo con la base de datos y ofrece una serie de funciones para la administración de la misma.
    /// </summary>
    public sealed class DataBase
    {
        // Lista de tablas en la BD:
        private const string CategoriaTable = "categoria";
        private const string SpanishTable = "fr_sp";
        private const string FrenchTable = "français";
        private const string RulesTable = "rules";
        private const string Rules_CatTable = "rules_categories";
        private const string SubcategoriaTable = "subcategoria";
        private const string InteractionTable = "interacciones";
        private const string IntQuestionsTable = "interacciones_preguntas";
        private const string IntAnswersTable = "interacciones_respuestas";
        private const string ConfigurationTable = "config";
        
        // Objetos de conexión con la BD.
        OleDbConnection _connection;
        OleDbCommand _command;

        // Dirección de la BD:
        private const string DbUrl = @"database.mdb";

        private int _hit1Amount;
        private int _hit2Amount;
        private int _hit3Amount;
        private int _removingDay;
        private int _startHitCounter;
        private bool _enabled;

        public List<FrenchWord> FrenchWords { get; private set; }
        public List<Categoria> CategoryList { get; private set; }
        public List<SpanishWord> SpanishWords { get; private set; }
        public List<Rule> Rules { get; private set; }
        public List<Interaction> Interactions { get; private set; }

#region Construction and Initialization

        /// <summary>
        /// Build the dataBase, initialize its resources, load it configuration, update it and finally load all data to memory.
        /// </summary>
        public DataBase()
        {
            InitializeDB();
            LoadConfiguration();
            if (_enabled)
                UpdateDB();
            LoadToMemory();
        }

        /// <summary>
        /// Stablish the connection with de DB and creates a command to make queries.
        /// </summary>
        private void InitializeDB()
        {
            _connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DbUrl);
            _connection.Open();
            _command = _connection.CreateCommand();
        }

        /// <summary>
        /// Load the configuration parameters of the DB into memory.
        /// </summary>
        private void LoadConfiguration()
        {
            OleDbDataReader reader = SelectQuery("*", ConfigurationTable);
            foreach (DbDataRecord item in reader)
            {
                _hit1Amount = (int) item[0];
                _hit2Amount = (int) item[1];
                _hit3Amount = (int) item[2];
                _removingDay = (int) item[3];
                _startHitCounter = (int) item[4];
                _enabled = (bool)item[5];
            }
            reader.Close();
        }

        /// <summary>
        /// Check for each word its last hit date and decrement hitCounter if needed. If hitCounter became 0 then the word is deleted from the DB.
        /// </summary>
        private void UpdateDB()
        {
            // Calculate expiration date and then selects only the words to update.
            DateTime todayDate = DateTime.Today;
            DateTime expirationDate = DateTime.Now.Subtract(new TimeSpan(_removingDay, 0, 0, 0));

            OleDbDataReader reader = SelectQuery("fr_word, hit_counter", FrenchTable, "last_hit_date <= #" + expirationDate +"#");
            IEnumerable<Tuple<string, int>> toUpdateWords = (from DbDataRecord item in reader select new Tuple<string, int>((string) item[0], ((int) item[1]) - 1)).ToList();
            reader.Close();

            foreach (var word in toUpdateWords)
            {
                if (word.Item2 == 0)
                    DeleteFrenchWord(word.Item1);
                else
                    UpdateQuery(FrenchTable, "hit_counter = " + word.Item2 + ", last_hit_date =#" + todayDate.Month + "/" + todayDate.Day + "/" + todayDate.Year + "#", "fr_word = '" + word.Item1 + "'");
            }
        }
        private void DeleteFrenchWord(string word)
        {
            DeleteQuery(FrenchTable, "fr_word = '" + word + "'");
        }
        private void DeleteRule(string name)
        {
            DeleteQuery(RulesTable, "rule_name = '" + name + "'");
        }
        private void DeleteInteraction(string name)
        {
            DeleteQuery(InteractionTable, "nombre = '" + name + "'");
        }

        /// <summary>
        /// Mapea la información relacional de la base de datos a un diseño orientado a objetos.
        /// Cargo la lista de categorías con sus sub_categorías.
        /// Cargo la lista de palabras francesas.
        /// Cargo las palabras españolas.
        /// </summary>
        private void LoadToMemory()
        {
            LoadCategorias();
            LoadFrenchWords();
            LoadRules();
            LoadInteractions();

            FrenchWords.Sort();
            //Rules.Sort();
            //Interactions.Sort();
        }
        /// <summary>
        /// Load the category list.
        /// </summary>
        private void LoadCategorias()
        {
            CategoryList = new List<Categoria>();

            DbDataReader categoryReader = SelectQuery("*", CategoriaTable);
            foreach (DbDataRecord categoryItem in categoryReader)
            {
                string categoryName = (string) categoryItem[0];

                // Guardo temporalmente _command;
                OleDbCommand tmpCommand = _command;
                _command = _connection.CreateCommand();

                // Selecciono todas las subcategorias de esta categoria.
                DbDataReader subcategoryReader = SelectQuery("*", SubcategoriaTable, "categoria = '" + categoryName + "'");
                IEnumerable<string> subCategories = (from DbDataRecord subcategoryItem in subcategoryReader select (string) subcategoryItem[0]).ToList();
                subcategoryReader.Close();

                CategoryList.Add(new Categoria(categoryName, subCategories));
                _command = tmpCommand;
            }
            categoryReader.Close();
        }
        /// <summary>
        /// Load french words.
        /// </summary>
        private void LoadFrenchWords()
        {
            FrenchWords = new List<FrenchWord>();
            
            DbDataReader reader = SelectQuery("*", FrenchTable);
            foreach (DbDataRecord item in reader)
            {
                string frWord = (string) item[0] ;
                string pronounce = item[1] is DBNull ? string.Empty : (string)item[1];
                string categoryName = (string) item[2];
                Categoria category = CategoryList.FirstOrDefault(categoryItem => categoryItem.CategoriaName.Equals(categoryName));
                string subcategoria = (string) item[3];
                string asocInvSimple = item[4] is DBNull ? string.Empty : (string)item[4];
                string asocInvCompleta = item[5] is DBNull ? string.Empty : (string)item[5];
                DateTime lastHitDate = (DateTime) item[6];
                int hitCounter = (int) item[7];
                int hitLevel = CalculateHitLevel(hitCounter);

                FrenchWords.Add(new FrenchWord(frWord, pronounce, category, subcategoria, asocInvSimple,
                    asocInvCompleta, lastHitDate, hitCounter, hitLevel));
            }
            reader.Close();

            LoadSpanishWords();
        }
        /// <summary>
        /// Load the spanish words and its relations.
        /// </summary>
        private void LoadSpanishWords()
        {
            SpanishWords = new List<SpanishWord>();

            DbDataReader reader = SelectQuery("*", SpanishTable);
            foreach (DbDataRecord spanishWordItem in reader)
            {
                string spWord = (string) spanishWordItem[0];
                string frWord = (string) spanishWordItem[1];

                // Buscar el objeto asociado a frWord;
                FrenchWord frenchWord = FrenchWords.FirstOrDefault(frenchWordItem => frWord.Equals(frenchWordItem.WordName));
                // Buscar si existe el objeto asociado a spWord;
                SpanishWord spanishWord = SpanishWords.FirstOrDefault(item2 => spWord.Equals(item2.WordName));
                if (spanishWord == null)
                {
                    spanishWord = new SpanishWord(spWord);
                    SpanishWords.Add(spanishWord);
                }
                                          
                spanishWord.FrenchWords.Add(frenchWord);
// ReSharper disable once PossibleNullReferenceException
                frenchWord.SpanishesWords.Add(spanishWord);
            }
            reader.Close();
        }
        /// <summary>
        /// Load rules.
        /// </summary>
        private void LoadRules()
        {
            Rules = new List<Rule>();

            DbDataReader reader = SelectQuery("*", RulesTable);
            foreach (DbDataRecord item in reader)
            {
                string name = (string)item[0];
                string description = (string)item[1];

                Rules.Add(new Rule(name, description));
            }
            reader.Close();

            reader = SelectQuery("*", Rules_CatTable);
            foreach (DbDataRecord item in reader)
	        {
                string ruleName = (string) item[0];
                string categoryName = (string) item[1];

		        // Buscar el objeto asociado a ruleName;
                Rule rule = Rules.FirstOrDefault(ruleItem => ruleName.Equals(ruleItem.Name));
                // Buscar el objeto asociado a categoryName;
                Categoria category = CategoryList.FirstOrDefault(categoryItem => categoryName.Equals(categoryItem.CategoriaName));

                rule.Categories.Add(category);
	        }
            reader.Close();
        }
        /// <summary>
        /// Load interactions
        /// </summary>
        private void LoadInteractions()
        {
            Interactions = new List<Interaction>();

            DbDataReader reader = SelectQuery("*", InteractionTable);
            foreach (DbDataRecord item in reader)
            {
                string name = (string)item[0];

                Interactions.Add(new Interaction(name));
            }
            reader.Close();

            LoadQ_A();
        }
        /// <summary>
        /// Load the interaction's questions and answers.
        /// </summary>
        private void LoadQ_A()
        {
            DbDataReader reader;
            foreach (var interactionItem in Interactions)
            {
                reader = SelectQuery("pregunta", IntQuestionsTable, "name_interaccion = '" + interactionItem.Name + "'");
                foreach (DbDataRecord questionItem in reader)
                {
                    string pregunta = (string)questionItem[0];

                    interactionItem.Questions.Add(pregunta);
                }
                reader.Close();
                reader = SelectQuery("respuesta", IntAnswersTable, "name_interaccion = '" + interactionItem.Name + "'");
                foreach (DbDataRecord answerItem in reader)
                {
                    string respuesta = (string)answerItem[0];

                    interactionItem.Answers.Add(respuesta);
                }
                reader.Close();
            }
        }
        #endregion

#region Communication with application.
        /// <summary>
        /// Insert a new french word into the data base. Also stablished all its relations with spanish words.
        /// </summary>
        /// <param name="word">The name of the new french word.</param>
        /// <param name="pronounce">The optional pronounciation of the new french word.</param>
        /// <param name="categoria">The categoria name of the new french word.</param>
        /// <param name="subcategoria">The subcategoria name of the new french word.</param>
        /// <param name="asocSimple">The optional simple asosiation of the new french word.</param>
        /// <param name="asocCompleta">The optional full asosiation of the new french word.</param>
        /// <param name="spanishesWords">The list of spanishes words names of the new french word.</param>
        public void InsertNewWord(string word, string pronounce, Categoria categoria, string subcategoria,
            string asocSimple, string asocCompleta, IEnumerable<string> spanishesWords)
        {
            DateTime lastHitDate = DateTime.Today;
            FrenchWord newFrenchWord = new FrenchWord(word, pronounce, categoria, subcategoria, asocSimple,
                asocCompleta, lastHitDate, _startHitCounter, CalculateHitLevel(_startHitCounter));
            FrenchWords.Add(newFrenchWord);

            InsertQuery(FrenchTable, "'" + word + "', '" + pronounce + "', '" + categoria + "', '" + subcategoria
                + "', '" + asocSimple + "', '" + asocCompleta
                + "', #" + lastHitDate.Month + "/" + lastHitDate.Day + "/" + lastHitDate.Year + "#, " + _startHitCounter);
            InsertSpanishWord(spanishesWords, newFrenchWord);
        }
        /// <summary>
        /// Insert the full list of spanish words and its relations with the frenchWord.
        /// </summary>
        /// <param name="spanishesWords">The list of words name to insert or update.</param>
        /// <param name="frenchWord">The french word related to the given list of spanish words.</param>
        private void InsertSpanishWord(IEnumerable<string> spanishesWords, FrenchWord frenchWord)
        {
            SpanishWord newSpanishWord;
            foreach (var literalSpanishWord in spanishesWords)
            {
                newSpanishWord = SpanishWords.FirstOrDefault(x => x.WordName.Equals(literalSpanishWord));
                if (newSpanishWord == null)
                {
                    newSpanishWord = new SpanishWord(literalSpanishWord);
                    SpanishWords.Add(newSpanishWord);
                }

                newSpanishWord.FrenchWords.Add(frenchWord);
                frenchWord.SpanishesWords.Add(newSpanishWord);
                InsertQuery(SpanishTable, "'" + literalSpanishWord + "', '" + frenchWord.WordName + "'");
            }
        }
        /// <summary>
        /// Hits an stored word. Increase its hit counter, update its hit level and set it last hit date to the current date.
        /// </summary>
        /// <param name="word">The name of the word to hit.</param>
        /// <returns>The object representing the word if it's stored, null otherwise.</returns>
        public void HitFrenchWord(FrenchWord frWord)
        {
            if (frWord != null)
            {
                frWord.LastHitDate = DateTime.Now;
                frWord.HitCounter++;
                frWord.HitLevel = CalculateHitLevel(frWord.HitCounter);   
            }
        }
        /// <summary>
        /// Porque soy un tramposo.
        /// </summary>
        /// <param name="frWord"></param>
        /// <param name="prevDate"></param>
        public void UnHitFrenchWord(FrenchWord frWord, DateTime prevDate)
        {
            if (frWord != null && frWord.HitCounter > 0)
            {
                frWord.LastHitDate = prevDate;
                frWord.HitCounter--;
                frWord.HitLevel = CalculateHitLevel(frWord.HitCounter);
            }
        }
        /// <summary>
        /// Calculate the current hit level according to the requirements of hits amount.
        /// </summary>
        /// <param name="hitCounter">The current hit counter of the word to analyze.</param>
        /// <returns>The hit level according to the preconfigured hit amounts.</returns>
        private int CalculateHitLevel(int hitCounter)
        {
            int hitLevel;
            if (hitCounter >= _hit3Amount)
                hitLevel = 3;
            else if (hitCounter >= _hit2Amount)
                hitLevel = 2;
            else if (hitCounter >= _hit1Amount)
                hitLevel = 1;
            else
                hitLevel = 0;
            return hitLevel;
        }
        /// <summary>
        /// Updates an existing frenchWord. Actually deletes it from the DataBase and re-insert it again, keeping the 
        /// updates of its lastHitDate and hitCounter.
        /// </summary>
        /// <param name="frenchWord">The existing french word.</param>
        /// <param name="newWord">The possible new name.</param>
        /// <param name="newPronounce">The possible new pronounce.</param>
        /// <param name="newCategoria">The possible new categoria.</param>
        /// <param name="newSubCategoria">The possible new subcategoria.</param>
        /// <param name="newAsocSimple">The possible new asocSimple.</param>
        /// <param name="newAsocCompleta">The possible new asocCompleta.</param>
        /// <param name="newSpanishWordsList">The possible new spanish words list.</param>
        public void UpdateExistingWord(FrenchWord frenchWord, string newWord, string newPronounce, Categoria newCategoria,
            string newSubCategoria, string newAsocSimple, string newAsocCompleta, IEnumerable<string> newSpanishWordsList)
        {
            DeleteFrenchWord(frenchWord.WordName);

            // Delete the spanishes words and its relations with this french word.
            foreach (var item in frenchWord.SpanishesWords)
                item.FrenchWords.Remove(frenchWord);
            frenchWord.SpanishesWords.Clear();

            // Insert the new french word:
            frenchWord.WordName = newWord;
            frenchWord.Pronounce = newPronounce;
            frenchWord.Categoria = newCategoria;
            frenchWord.Subcategoria = newSubCategoria;
            frenchWord.AsocSimple = newAsocSimple;
            frenchWord.AsocCompleta = newAsocCompleta;

            // Insert the word and its associated onto the DB.
            InsertQuery(FrenchTable, "'" + newWord + "', '" + newPronounce + "', '" + newCategoria + "', '" + newSubCategoria + "', '" + newAsocSimple
                + "', '" + newAsocCompleta + "', #" + frenchWord.LastHitDate.Month + "/" + frenchWord.LastHitDate.Day + "/" + frenchWord.LastHitDate.Year + "#, " + frenchWord.HitCounter);
            InsertSpanishWord(newSpanishWordsList, frenchWord);
        }
        /// <summary>
        /// Interface for removing of unwanted words.
        /// </summary>
        /// <param name="frWord">The french word object to remove.</param>
        public void RemoveFrenchWord(FrenchWord frWord)
        {
            foreach (var item in frWord.SpanishesWords)
            {
                item.FrenchWords.Remove(frWord);
                if (item.FrenchWords.Count == 0)
                    SpanishWords.Remove(item);
            }

            FrenchWords.Remove(frWord);
            DeleteFrenchWord(frWord.WordName);
        }

        /// <summary>
        /// Insert a new rule into the system.
        /// </summary>
        /// <param name="newRule"></param>
        public void InsertNewRule(string newName, string newDescription, List<Categoria> newCategories)
        {
            Rule newRule = new Rule(newName, newDescription);
            newRule.Categories = newCategories;
            Rules.Add(newRule);

            InsertRule(newName, newDescription, newCategories);
        }
        /// <summary>
        /// Centraliza las inserciones finales de reglas en la BD.
        /// </summary>
        /// <param name="name">Nombre de la regla.</param>
        /// <param name="description">Descripción de la regla.</param>
        /// <param name="categories">Categoría de la regla.</param>
        private void InsertRule(string name, string description, List<Categoria> categories)
        {
            InsertQuery(RulesTable, "'" + name + "', '" + description + "'");
            // Inserting the relations rule_cat:
            foreach (var item in categories)
                InsertQuery(Rules_CatTable, "'" + name + "', '" + item.CategoriaName + "'");
        }
        /// <summary>
        /// Updates an existing rule. Actually deletes it from the DataBase and re-insert it again.
        /// </summary>
        /// <param name="rule">The current rule.</param>
        /// <param name="newName">The possible new name.</param>
        /// <param name="newDescription">The possible new pronounce.</param>
        /// <param name="newCategories">The possible new categories.</param>
        public void UpdateExistingRule(Rule rule, string newName, string newDescription, List<Categoria> newCategories)
        {
            DeleteRule(rule.Name);
            rule.Categories.Clear();

            // Insert the new rule:
            rule.Name = newName;
            rule.Description = newDescription;
            rule.Categories = newCategories;

            InsertRule(newName, newDescription, newCategories);
        }
        /// <summary>
        /// Interface for the removing of unwanted rules.
        /// </summary>
        /// <param name="rule">The rule object to remove.</param>
        public void RemoveRule(Rule rule)
        {
            Rules.Remove(rule);
            DeleteRule(rule.Name);
        }

        /// <summary>
        /// Insert a new interaction into the data base.
        /// </summary>
        /// <param name="name">The name of the new interaction.</param>
        /// <param name="description">The list of questions for the given interaction.</param>
        /// <param name="categories">The list of answers for the given interaction.</param>
        public void InsertNewInteraction(string name, List<string> questions, List<string> answers)
        {
            Interaction newInteraction = new Interaction(name);
            newInteraction.Questions = questions;
            newInteraction.Answers = answers;
            Interactions.Add(newInteraction);

            InsertInteraction(name, questions, answers);
        }
        /// <summary>
        /// Centraliza las inserciones finales de interacciones en la BD.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="questions"></param>
        /// <param name="answers"></param>
        private void InsertInteraction(string name, List<string> questions, List<string> answers)
        {
            InsertQuery(InteractionTable, "'" + name + "'");
            // Inserting the relations interacciones_preguntas:
            foreach (var item in questions)
                InsertQuery(IntQuestionsTable, "'" + item + "', '" + name + "'");
            // Inserting the relations interacciones_respuestas:
            foreach (var item in answers)
                InsertQuery(IntAnswersTable, "'" + item + "', '" + name + "'");
        }
        /// <summary>
        /// Updates an existing interaction. Actually deletes it from the DataBase and re-insert it again.
        /// </summary>
        /// <param name="interaction">The current interaction.</param>
        /// <param name="newName">The possible new name.</param>
        /// <param name="newQuestions">The posible new questions.</param>
        /// <param name="newAnsers">The possible new ansers.</param>
        public void UpdateExistingInteraction(Interaction interaction, string newName, List<string> newQuestions, List<string> newAnsers)
        {
            DeleteInteraction(interaction.Name);
            interaction.Questions.Clear();
            interaction.Answers.Clear();

            // Insert the new interaction:
            interaction.Name = newName;
            interaction.Questions = newQuestions;
            interaction.Answers = newAnsers;

            InsertInteraction(newName, newQuestions, newAnsers);
        }
        /// <summary>
        /// Interface for the removing of unwanted interactions.
        /// </summary>
        /// <param name="interaction">The interaction object to remove.</param>
        public void RemoveInteraction(Interaction interaction)
        {
            Interactions.Remove(interaction);
            DeleteInteraction(interaction.Name);
        }
        
#endregion

#region DB-Wrapping
        OleDbDataReader SelectQuery(string cols, string table, string whereStatement = "")
        {
            string query = "SELECT " + cols + " FROM " + table;
            _command.CommandText = (whereStatement != "" ? AppendWhere(query, whereStatement) : query);
            return _command.ExecuteReader();
        }
        void UpdateQuery(string table, string fieldsValues, string whereStatement = "")
        {
            string query = "UPDATE " + table + " SET " + fieldsValues + "";
            query = (whereStatement != "" ? AppendWhere(query, whereStatement) : query);
            ExecuteNonQuery(query);
        }
        void InsertQuery(string table, string values, string whereStatement = "")
        {
            string query = "INSERT INTO " + table + " VALUES (" + values + ")";
            query = (whereStatement != "" ? AppendWhere(query, whereStatement) : query);
            ExecuteNonQuery(query);
        }
        void DeleteQuery(string table, string whereStatement = "")
        {
            string query = "DELETE FROM " + table;
            query = (whereStatement != "" ? AppendWhere(query, whereStatement) : query);
            ExecuteNonQuery(query);
        }
        string AppendWhere(string query, string whereStatement)
        {
            return query + " WHERE " + whereStatement;
        }
        void ExecuteNonQuery(string completedQuery)
        {
            _command.CommandText = completedQuery;
            int result = _command.ExecuteNonQuery();
            if (result == -1)
                throw new Exception("Error al insertar el record");
        }
#endregion
    }
}
