using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonLibrary
{
    /// <summary>
    /// The class for sorting data. 
    /// </summary>
    public static class DataSort
    {
        public static int CompareTo(this Hero character1, Hero character2, FieldType fieldtype)
        {
            switch (fieldtype)
            {
                case FieldType.HERO_ID:
                    return character1.HeroId.CompareTo(character2.HeroId);
                case FieldType.HERO_NAME:
                    return character1.HeroName.CompareTo(character2.HeroName);
                case FieldType.FACTION:
                    return character1.Faction.CompareTo(character2.Faction);
                case FieldType.LEVEL:
                    return character1.HeroLevel.CompareTo(character2.HeroLevel);
                case FieldType.CASTLE_LOCATION:
                    return character1.CastleLocation.CompareTo(character2.CastleLocation);
                default:
                    throw new ArgumentException("Неподдерживаемый тип сортировки");

            }
        }
    }
}
