/*
In this project, I use lists and LINQ to search a database to 
see when some of my favorite programming languages were invented.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
  class Program
  {
    static void Main()
    {
      List<Language> languages = File.ReadAllLines("./languages.tsv")
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();

      // Step 1
      // Print all of the languages
      foreach (var language in languages) 
      {
        // Uncomment code below to print
        //Console.WriteLine(language.Prettify());
        
        // Step 2
        var qString = languages.Select(s => $"{s.Year}, {s.Name}, {s.ChiefDeveloper}");

        foreach (var q in qString) 
        {
          // Uncomment code below to print
          //Console.WriteLine(q);
        }
      }
    
      // Step 3
      // Find language(s) with the name C#
      var cSharpLanguages = languages.Where(c => c.Name.Contains("C#"))
      .Select(c => c);

      foreach (var cSharp in cSharpLanguages)
      {
        // Uncomment code below to print
        //Console.WriteLine(cSharp.Prettify());
      }

      // Step 4
      // Find all languages with MIcrosoft included in their ChiefDeveloper
      var microsoftLanguages = languages.Where(m => m.ChiefDeveloper.Contains("Microsoft"))
      .Select(m => m);

      foreach (var microsoft in microsoftLanguages)
      {
        // Uncomment code below to print
        //Console.WriteLine(microsoft.Prettify());
      }

      // Step 5
      // Find all languages that descend from Lisp
      var lispLanguages = languages.Where(l => l.Predecessors.Contains("Lisp"))
      .Select(l => l);

      foreach (var lisp in lispLanguages)
      {
        // Uncomment code below to print
        //Console.WriteLine(lisp.Prettify());
      }

      // Step 6
      // Find all language names that contain the word Script
      var scriptLanguages = from n in languages
        where n.Name.Contains("Script")
        select n;

      foreach (var script in scriptLanguages)
      {
        // Uncomment code below to print
        //Console.WriteLine(script.Prettify());
      }

      // Step 7
      // Find how many languages are included in the languages list
      var numberLanguages = from num in languages
          select num;
      // Uncomment code below to print
      //Console.WriteLine(numberLanguages.Count());

      // Step 8
      // Find how many languages were launched between 1995 and 2005
      var periodLanguages = from p in languages
          where p.Year >= 1995 && p.Year <= 2005
          select p;
      // Uncomment code below to print
      //Console.WriteLine(periodLanguages.Count());

      // Step 9
      // Print a string for each of those languages
      var addOnPrevious = from a in languages
          select $"{a.Name} was invented in {a.Year}";
          foreach (string addOn in addOnPrevious) 
          {
            // Uncomment code below to print
            //Console.WriteLine(addOn);
          }
      
      // Step 10b
      var everyLanguage = from every in languages
          select every;

        // Uncomment code below to see in terminal
        //Language.PrettyPrintAll(everyLanguage);

      //Step 11b
      var everyQuery = from all in languages
          select $"{all.Name} was invented in {all.Year}";
      
      // Uncomment code below to print every query result in this project
      //Language.PrintAll(everyQuery);
    }
  }
}
