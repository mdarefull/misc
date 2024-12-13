using System;
using System.Collections.Generic;

namespace Français_Helper
{
    public abstract class Word : IComparable
    {
        public Word(string word)
        {
            WordName = word;
        }

        public string WordName { get; set; }

        public override string ToString()
        {
            return WordName;
        }

        public int CompareTo(object obj)
        {
            if (obj is Word)
                return MyAlgorithmsStore.MyStringComparer(this.WordName, (obj as Word).WordName);

            throw new ArgumentException("Incompatibles elements");
        }
    }
    public class FrenchWord : Word
    {
        
        public FrenchWord(string word, string pronounce, Categoria categoria, string subcategoria, string asocSimple,
            string asocCompleta, DateTime lastHitDate, int hitCounter, int hitLevel)
            : base(word)
        {
            Pronounce = pronounce;
            Categoria = categoria;
            Subcategoria = subcategoria;
            AsocSimple = asocSimple;
            AsocCompleta = asocCompleta;
            LastHitDate = lastHitDate;
            HitCounter = hitCounter;
            SpanishesWords = new List<SpanishWord>();
            HitLevel = hitLevel;

        }

        public string Pronounce { get; set; }
        public Categoria Categoria { get; set; }
        public string Subcategoria { get; set; }
        public string AsocSimple { get; set; }
        public string AsocCompleta { get; set; }
        public DateTime LastHitDate { get; set; }
        public int HitCounter { get; set; }
        public List<SpanishWord> SpanishesWords { get; set; } 
        public int HitLevel { get; set; }
    }

    public class SpanishWord : Word
    {
        public SpanishWord(string word)
            : base(word)
        {
            WordName = word;
            FrenchWords = new List<FrenchWord>();
        }

        public List<FrenchWord> FrenchWords { get; set; }
    }
    public class Categoria
    {
        public Categoria(string name, IEnumerable<string> subcategories)
        {
            CategoriaName = name;
            Subcategories = subcategories;
        }

        public string CategoriaName { get; set; }
        public IEnumerable<string> Subcategories { get; set; }

        public override string ToString()
        {
            return CategoriaName;
        }
    }

    public class Rule
    {
        public Rule(string name, string description)
        {
            Name = name;
            Description = description;
            Categories = new List<Categoria>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Categoria> Categories { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Interaction
    {
        public Interaction(string name)
        {
            Name = name;
            
            Questions = new List<string>();
            Answers = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Questions { get; set; }
        public List<string> Answers { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
