
using JsonLibrary;

namespace ConsoleApp
{
    public static class DataFilter
    {
        public static List<Hero> FilterByField(List<Hero> list, FieldType field, string value)
        {
            List<Hero> filteredValues = new();
            foreach (var customer in list)
            {
                if (FilterField(customer, field, value))
                {
                    filteredValues.Add(customer);
                }
            }
            return filteredValues;
        }
        public static bool FilterField(Hero customer, FieldType field, string value)
        {
            switch (field)
            {
                case FieldType.HERO_NAME:
                    return customer.HeroName == value;
                case FieldType.HERO_ID:
                    int number;
                    if (int.TryParse(value, out number))
                    {
                        return customer.HeroId == number;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect format for field 'Hero_id'");
                        return false;
                    }
                case FieldType.FACTION:
                    return customer.Faction == value;
                case FieldType.CASTLE_LOCATION:
                    return customer.CastleLocation == value;
                case FieldType.LEVEL:
                    int lvl;
                    if (int.TryParse(value, out lvl))
                    {
                        return customer.HeroLevel == lvl;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect format for field 'Hero_level'");
                        return false;
                    }
                
                default:
                    Console.WriteLine("Incorrect field for filtering");
                    return false;
            }
        }
    }
}

///<summary>
///Альтернативное решение может быть использование LINQ для фильтрации данных. 
///Вместо явного цикла и проверок через switch, можно воспользоваться методами LINQ для удобного и читаемого фильтра списка данных. 
///Например, вы можете переписать метод FilterByField следующим образом:
///Возможное альтернативное решение представлено ниже.
///</summary>
/*
public static class DataFilter
{
    public static List<CustomerData> FilterByField(List<Hero> list, FieldType field, string value)
    {
        switch (field)
        {
            case FieldType.HERO_NAME:
                return list.Where(hero => hero.HeroName == value).ToList();
            case FieldType.HERO_ID:
                if (int.TryParse(value, out int number))
                {
                    return list.Where(customer => customer.HeroId == number).ToList();
                }
                else
                {
                    Console.WriteLine("Incorrect format for field 'HeroId'");
                    return new List<Hero>();
                }
            case FieldType.FACTION:
                return list.Where(customer => customer.Faction == value).ToList();
            case FieldType.CASTLE_LOCATION:
                return list.Where(customer => customer.CastleLocation == value).ToList();
            case FieldType.LEVEL:
                if (int.TryParse(value, out int age))
                {
                    return list.Where(customer => customer.HeroLevel == age).ToList();
                }
                else
                {
                    Console.WriteLine("Incorrect format for field 'HeroLevel'");
                    return new List<Hero>();
                }
            default:
                Console.WriteLine("Incorrect field for filtering");
                return new List<Hero>();
        }
    }
}

 */
