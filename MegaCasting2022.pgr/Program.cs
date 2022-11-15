using MegaCasting2022.DBLib.Class;

MegaCastingCsharpContext context = new MegaCastingCsharpContext();

context.Activities.ToList().ForEach(activity => Console.WriteLine(activity.Identifier + " - " + activity.Name));

// Ajout
context.Activities
    .Add(new Activity() { Name = "Doc" });
context.SaveChanges();

// Suppression
context.Activities.Remove(context.Activities
    .OrderBy(civ => civ.Identifier)
    .Last());

// Modification
Activity activity = context.Activities
    .OrderByDescending(civ => civ.Identifier)
    .First();

activity.Name = "Docteur";
context.SaveChanges();

Console.ReadKey();