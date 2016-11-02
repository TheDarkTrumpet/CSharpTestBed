<Query Kind="Statements" />

	ClassWithAttributes classToSupplement = new ClassWithAttributes();
	ClassToPopulateFrom.SupplementObject(classToSupplement).Dump();
}

public class ClassWithAttributes
{
	public string AttributeA { get; set; }
	public string AttributeB { get; set; }
	public string AttributeC { get; set;}
}

public static class ClassToPopulateFrom
{
	public static Object SupplementObject(Object a)
	{
		Type classType = a.GetType();

		foreach (var m in classType.GetMethods().Where(x => x.Name.StartsWith("set")))
		{
			string methodName = m.Name.Replace("set_", "");
			object[] parameters = new object[] { GetAttributeFromString(methodName) };
			m.Invoke(a, parameters);
		}
		return a;
	}

	public static string GetAttributeFromString(string attribute)
	{
		switch (attribute)
		{
			case "AttributeA":
				return "Supplemental from AttributeA";
			case "AttributeB":
				return "Supplemental from AttributeB";
			case "AttributeC":
				return "Supplemental from AttributeC";
		}
		return "Supplemental from default...";
	}
