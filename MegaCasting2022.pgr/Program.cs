using MegaCasting2022.DBLib.Class;

MegaCastingCsharpContext context = new MegaCastingCsharpContext();

context.Activities.ToList().ForEach(activity => Console.WriteLine(activity.Identifier + " - " + activity.Name));

Console.WriteLine("Voulez-vous ajouter (1) ou supprimer (2) des données de cette liste ?");

switch (Console.ReadLine())
{
	case "1":
		Console.Clear();
        context.Activities.ToList().ForEach(activity => Console.WriteLine(activity.Identifier + " - " + activity.Name));
        Console.WriteLine("Quel est l'identifiant de l'activité à supprimer ?");
		string entree = Console.ReadLine();
		foreach (Activity act in context.Activities)
		{
			if(act.Identifier.ToString() == entree)
			{
				Console.WriteLine(context.Activities.Where(activity => activity.Identifier.ToString() == entree));
			}
		}
		Console.ReadLine();
		break;
	case "2":
		break;
	case "0":
		break;
	default:
		break;
}