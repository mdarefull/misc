using KnowledgeMap.Data.EF;
using KnowledgeMap.Data.EF.Migrations;
using KnowledgeMap.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Linq;

namespace KnowledgeMap.Application.Mvc.DiExternalModule
{
    internal sealed class KnowledgeMapMvcDbConfig : KnowledgeMapDbConfig
    {
        protected sealed override void SetDatabaseInitializer()
        {
            SetDatabaseInitializer(new MigrateDatabaseToLatestVersion<KnowledgeMapDbContext, Configuration>(true));
        }
        protected sealed override void DbSeeder(KnowledgeMapDbContext context)
        {
            // Only perform the seeding when there's no registered topics.
            // TODO [CHECK] The fact I've done it this way, is because I cannot implement this method coupled
            //      to the base's implementation.
            var emptyDb = context.Topics.Count() == 0;

            base.DbSeeder(context);

#if DEBUG
            if (emptyDb)
            {
                AddDebugTopicData(context.Topics);
                context.SaveChanges();
            }
#endif
        }
        private void AddDebugTopicData(DbSet<Topic> topics)
        {
            var universe = topics.Find(1);

            // The goal of this is to have a view full of references.
            #region More on Universe
            {
                var teethReference = new Reference
                {
                    Name = "Teeth's brush method",
                    Description = "Vídeo about how to correctly brush your teeths.\nMost interesting part at 1:28",
                    Owner = universe,
                    TargetUrl = new Uri("http://www.odontologyforall.org/teeth/brushmethod.mp4").ToString(),
                };
                var ragdoll = new Reference
                {
                    Name = "Ragdoll: The nicest cat's breed",
                    Description = "Excelent doccument explaining all the details about the Ragdolls",
                    Owner = universe,
                    TargetUrl = new Uri("http://catsparadise.com/ragdoll/allAboutIt.pdf").ToString(),
                };
                var watermellon = new Reference
                {
                    Name = "Properties about the watermellon",
                    Description = "Nature's magazine article related to all the good properties of the watermellon",
                    Owner = universe,
                    TargetUrl = new Uri("https://naturemagazine.uk/articles?id=12457&title=watermellon").ToString(),
                };
                universe.References = new List<Reference>
                    {
                        teethReference, ragdoll, watermellon
                    };

                var ref1 = new Reference
                {
                    Name = "Spicy jalapeno bacon ipsum dolor amet",
                    Description = "Voluptate t-bone cillum filet mignon kielbasa. Chicken tongue laboris fatback magna corned beef, ad pork burgdoggen cupim cillum. Aliqua sausage chuck alcatra adipisicing ham ut t-bone, cupim biltong filet mignon pancetta. Ut filet mignon enim eiusmod burgdoggen. Nulla id quis leberkas filet mignon cillum.",
                    TargetUrl = new Uri("http://bbb.org").ToString(),
                };
                universe.References.Add(ref1);
                ref1 = new Reference
                {
                    Name = "Trembling Darkness",
                    Description = "Spicy jalapeno bacon ipsum dolor amet pariatur eu sunt capicola. Exercitation bacon ipsum bresaola venison, consectetur corned beef leberkas dolore. In nisi labore, reprehenderit flank drumstick deserunt picanha sed bresaola. Chicken filet mignon salami tenderloin ad mollit. Shank biltong spare ribs laborum sint consectetur, brisket beef swine. Officia dolore excepteur, chuck strip steak kielbasa anim frankfurter sed do ullamco laborum short ribs. Tail aliqua in eiusmod labore.",
                    TargetUrl = new Uri("http://hoguesos.com").ToString(),
                };
                universe.References.Add(ref1);
                ref1 = new Reference
                {
                    Name = "The Willing Shards",
                    Description = "Ullamco dolor minim, jowl sunt beef ribs ut dolore ad cupidatat. Turducken anim turkey kevin. Culpa t-bone boudin ham hock, kielbasa dolore pig sint reprehenderit dolore shank. Nisi jerky rump ullamco, aliquip venison leberkas in voluptate burgdoggen doner short loin dolor sed. Meatloaf bacon incididunt pork loin pastrami veniam ex dolore ea id meatball deserunt alcatra consequat. Corned beef t-bone kevin spare ribs. Cillum picanha filet mignon, mollit pig officia lorem jerky tempor veniam doner.",
                    TargetUrl = new Uri("http://getjobingulf.com").ToString(),
                };
                universe.References.Add(ref1);
                ref1 = new Reference
                {
                    Name = "Wind of Touch",
                    Description = "Doner cupidatat brisket, fatback cow strip steak leberkas sed dolore pariatur magna. Andouille pork salami ham hock tail duis capicola pork loin adipisicing short ribs frankfurter short loin filet mignon nisi velit. Incididunt sirloin sint fatback, drumstick chuck ad tri-tip jerky picanha beef dolore meatloaf leberkas sed. Ad short loin officia beef boudin. Pork chop quis kevin, sirloin laborum nisi aliqua esse rump proident in sed nulla. Esse hamburger ipsum consectetur, ullamco turkey fatback ham proident tempor minim swine andouille turducken chuck. Strip steak sirloin ut flank commodo culpa boudin voluptate, mollit swine.",
                    TargetUrl = new Uri("http://wesalam.com").ToString(),
                };
                universe.References.Add(ref1);
                ref1 = new Reference
                {
                    Name = "The Roses's History",
                    TargetUrl = new Uri("http://staceyplusmike.com").ToString(),
                };
                universe.References.Add(ref1);
                ref1 = new Reference
                {
                    Name = "The Secrets of the Thoughts",
                    Description = "Laborum sed capicola officia labore, non chicken. Andouille dolor rump landjaeger ham hock. Pork chop dolore et, leberkas enim voluptate pig magna ribeye pork. Tongue picanha short loin veniam labore fatback non.",
                    TargetUrl = new Uri("http://elitebhc.com").ToString(),
                };
                universe.References.Add(ref1);
                ref1 = new Reference
                {
                    Name = "Child in the Healing",
                    Description = "Mollit excepteur salami boudin tenderloin. Ball tip flank do, pastrami ea nulla meatball sausage ut. Occaecat brisket ut biltong ut, culpa duis sunt kevin qui consectetur picanha turkey drumstick elit. Excepteur chicken ball tip pork chop. Tail dolore shank pastrami laboris leberkas.",
                    TargetUrl = new Uri("http://successischosen.com").ToString(),
                };
                universe.References.Add(ref1);
                ref1 = new Reference
                {
                    Name = "Black Emperor",
                    TargetUrl = new Uri("http://submarinies.com").ToString(),
                };
                universe.References.Add(ref1);
                ref1 = new Reference
                {
                    Name = "The Laughing Flowers",
                    TargetUrl = new Uri("http://nottheincumbent.com").ToString(),
                };
                universe.References.Add(ref1);

                var others = new List<Reference>();
                var rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    var newReference = new Reference { Owner = universe, };

                    var encoder = Encoding.ASCII;

                    var rndByteArr = new byte[rnd.Next(1, 10)];
                    rnd.NextBytes(rndByteArr);
                    newReference.Name = encoder.GetString(rndByteArr);

                    rndByteArr = new byte[rnd.Next(0, 100)];
                    rnd.NextBytes(rndByteArr);
                    newReference.Description = encoder.GetString(rndByteArr);

                    rndByteArr = new byte[rnd.Next(1, 50)];
                    rnd.NextBytes(rndByteArr);
                    newReference.TargetUrl = string.Format("http://www.{0}.com", encoder.GetString(rndByteArr));

                    others.Add(newReference);
                }
                universe.References.AddRange(others);
            }

            #endregion

            // The goal of this is to have nested topics and references.
            #region CS Topic
            var computerScience = new Topic
            {
                Name = "Computer Science",
                Description = "This is my computer science topic, where all CS related knowledge is stored.",
                Owner = universe,
            };
            topics.Add(computerScience);

            var windowsServices = new Reference
            {
                Name = "Disable unused windows services",
                Owner = computerScience,
                TargetUrl = "http://www.badurl.com",
            };
            var onlineInterviews = new Reference
            {
                Name = "Interview Zen",
                Owner = computerScience,
                Description = "Online Technical Interview and Recruitment Software",
                TargetUrl = new Uri("https://www.interviewzen.com/").ToString(),
            };
            var microphone = new Reference
            {
                Name = "How to use your smartphone as a windows microphone",
                Owner = computerScience,
                TargetUrl = new Uri("http://www.makeuseof.com/tag/use-smartphone-windows-microphone/").ToString(),
            };
            computerScience.References = new List<Reference>
                {
                    windowsServices, onlineInterviews, microphone,
                };

            #region Algorithms Topic
            var algorithms = new Topic
            {
                Name = "Algorithms & DS",
                Owner = computerScience,
            };
            topics.Add(algorithms);
            var suffixArray = new Reference
            {
                Name = "Suffix Array applications",
                Owner = algorithms,
                TargetUrl = "badURL",
            };
            algorithms.References = new List<Reference>
                {
                    suffixArray,
                };

            var sorting = new Topic
            {
                Name = "Sorting Algorithms",
                Owner = algorithms,
                Description = "Knowledge related to sorting algorithms",
            };
            topics.Add(sorting);
            var mergeSort = new Reference { Name = "Merge Sort", TargetUrl = "badURL", Owner = sorting };
            var quickSort = new Reference { Name = "Quick Sort", TargetUrl = "badURL", Owner = sorting };
            var bubleSort = new Reference { Name = "Bubble Sort", TargetUrl = "badUrl", Owner = sorting };
            var insertionSort = new Reference { Name = "InsertionSort", TargetUrl = "badURL", Owner = sorting };
            var bucketSort = new Reference { Name = "BucketSort", TargetUrl = "badURL", Owner = sorting };
            var quickSortImpl = new Reference { Name = "Quick Sort Implementation js", TargetUrl = "badURL", Owner = sorting };
            var radixSort = new Reference { Name = "Radix Sort", TargetUrl = "badURL", Owner = sorting };
            sorting.References = new List<Reference> { mergeSort, quickSort, bubleSort, insertionSort, bucketSort, quickSortImpl, radixSort };

            var subtopic1 = new Topic { Name = "Sample Subtopic A", Owner = sorting };
            var subtopic2 = new Topic { Name = "Sample Subtopic B", Owner = subtopic1 };
            var subtopic3 = new Topic { Name = "Sample Subtopic C", Owner = subtopic2 };
            var subtopic4 = new Topic { Name = "Sample Subtopic D", Owner = subtopic3 };
            var subtopic5 = new Topic { Name = "Sample Subtopic E", Owner = subtopic4 };
            topics.AddRange(new[] { subtopic1, subtopic2, subtopic3, subtopic4, subtopic5 });

            var graphs = new Topic
            {
                Name = "Graph algorithms",
                Owner = algorithms,
                Description = "Knowledge related to graph algorithms",
            };
            topics.Add(graphs);
            var st = new Reference { Name = "Spanning Tree", TargetUrl = "badURL", Owner = graphs };
            var mst = new Reference { Name = "Minimum Spanning Tree", TargetUrl = "badURL", Owner = graphs };
            var kruskal = new Reference { Name = "Kruskal", TargetUrl = "badURL", Owner = graphs };
            var prim = new Reference { Name = "Prim", TargetUrl = "badURL", Owner = graphs };
            var dijkstra = new Reference { Name = "Dijkstra", TargetUrl = "badURL", Owner = graphs };
            var floyd = new Reference { Name = "Floyd", TargetUrl = "badURL", Owner = graphs };
            var plannarGraphs = new Reference { Name = "Plannar Graphs", TargetUrl = "badURL", Owner = graphs };
            var matching = new Reference { Name = "Matching", TargetUrl = "badURL", Owner = graphs };
            var bipartite = new Reference { Name = "Bipartite Graphs", TargetUrl = "badURL", Owner = graphs };
            var bfs = new Reference { Name = "BFS", TargetUrl = "badURL", Owner = graphs };
            var dfs = new Reference { Name = "DFS", TargetUrl = "badURL", Owner = graphs };
            graphs.References = new List<Reference> { st, mst, kruskal, prim, dijkstra, floyd, plannarGraphs, matching, bipartite, bfs, dfs, };
            #endregion

            #region C# Topic
            var cSharp = new Topic
            {
                Name = "C#",
                Owner = computerScience,
                Description = "C# programming language related knowledge",
            };
            topics.Add(cSharp);
            #endregion

            #region Software Engineering Topic
            var softwareEngineering = new Topic
            {
                Name = "Software Engineering",
                Owner = computerScience,
                Description = "Software design patterns and principles.",
            };
            topics.Add(softwareEngineering);
            #endregion
            #endregion
            #region Language Topic
            var languages = new Topic
            {
                Name = "Languages",
                Owner = universe,
                Description = "This is my langauge topic, where all langauges related knowledge is stored.",
            };
            topics.Add(languages);
            #endregion

            // The goal of this is to have a view full of subtopics
            #region Random SubTopics
            {
                var subtopic = new Topic
                {
                    Name = "Voyagers of Secret",
                    Description = "Ut jerky ut sint ullamco nisi nostrud ribeye irure in meatloaf cillum chicken pork aliquip. Aliquip veniam fatback, elit t-bone boudin pork chop consequat magna ham hock hamburger. Beef ribs kevin pig ipsum. Doner in ham irure dolor occaecat. Leberkas ea aliquip, shoulder occaecat capicola short ribs reprehenderit kielbasa elit spare ribs.",
                    Owner = universe,
                };
                topics.Add(subtopic);

                subtopic = new Topic
                {
                    Name = "The Tears's Truth",
                    Description = "",
                    Owner = universe,
                };
                topics.Add(subtopic);

                subtopic = new Topic
                {
                    Name = "The Crying of the Windows",
                    Description = "Biltong porchetta leberkas deserunt, laborum in duis ut pork belly capicola drumstick. Pork flank eu, kielbasa qui leberkas deserunt drumstick swine frankfurter. Pig flank ipsum cillum filet mignon sed. Brisket pork chop t-bone et ham hock deserunt ullamco picanha sirloin enim pork belly. Excepteur ut minim bacon.",
                    Owner = universe,
                };
                topics.Add(subtopic);

                subtopic = new Topic
                {
                    Name = "Soul in the Touch",
                    Description = "",
                    Owner = universe,
                };
                topics.Add(subtopic);

                subtopic = new Topic
                {
                    Name = "Lost Flower",
                    Description = "Consectetur short ribs ex officia. Velit burgdoggen ham kielbasa. Sausage sint rump pastrami do ut. Do frankfurter sint hamburger ut turducken cupim minim strip steak.",
                    Owner = universe,
                };
                topics.Add(subtopic);

                subtopic = new Topic
                {
                    Name = "The Ravaged Touch",
                    Description = "Shank porchetta ex jowl rump sunt kielbasa dolore short ribs. Tongue lorem ullamco ribeye, commodo pork loin flank irure tempor id beef capicola hamburger boudin consequat. Andouille quis irure, beef ribs non in pork hamburger. T-bone bacon turducken pancetta brisket, biltong cow short loin. Pork loin nisi tongue elit dolore qui ex cupidatat sirloin. Fugiat ad ham eiusmod laborum ut shank magna sed ea chicken consectetur pork capicola minim.",
                    Owner = universe,
                };
                topics.Add(subtopic);

                subtopic = new Topic
                {
                    Name = "Spirits of Women",
                    Description = "Kevin dolore consequat spare ribs, adipisicing corned beef venison. Venison cillum meatball velit ham hock dolore frankfurter consequat sint drumstick tri-tip commodo. Swine andouille pork belly hamburger cow brisket fatback pork chop cillum. Bresaola veniam prosciutto, tongue beef porchetta in occaecat magna doner tri-tip flank non ad. Dolore eu landjaeger et pork belly excepteur est jowl quis meatball shoulder drumstick alcatra reprehenderit.",
                    Owner = universe,
                };
                topics.Add(subtopic);

                subtopic = new Topic
                {
                    Name = "The Spirit's Person",
                    Owner = universe,
                };
                topics.Add(subtopic);

                subtopic = new Topic
                {
                    Name = "The Danger of the Snake",
                    Description = "Nostrud dolor burgdoggen hamburger capicola kielbasa. Exercitation eiusmod t-bone, swine burgdoggen ipsum shankle laboris strip steak venison commodo pancetta jerky in. Sint aliqua dolore, cupidatat laborum veniam beef doner nisi et pastrami cow ut tenderloin id. Velit ipsum mollit salami, beef ribs fugiat commodo venison ground round jowl ham turkey. Ut chuck andouille laboris capicola, sunt shankle laborum bresaola eiusmod shoulder doner meatball corned beef. Filet mignon leberkas ut culpa non fugiat. Fatback ball tip sunt, alcatra magna doner dolore beef ribs ea cupim voluptate pastrami.",
                    Owner = universe,
                };
                topics.Add(subtopic);

                var others = new List<Topic>();
                var rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    var newTopic = new Topic { Owner = universe, };

                    var encoder = Encoding.ASCII;

                    var rndByteArr = new byte[rnd.Next(1, 10)];
                    rnd.NextBytes(rndByteArr);
                    newTopic.Name = encoder.GetString(rndByteArr);

                    rndByteArr = new byte[rnd.Next(0, 100)];
                    rnd.NextBytes(rndByteArr);
                    newTopic.Description = encoder.GetString(rndByteArr);

                    others.Add(newTopic);
                }
            }
            #endregion
        }
    }
}