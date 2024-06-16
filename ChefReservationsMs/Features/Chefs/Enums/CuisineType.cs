using System.ComponentModel;

namespace ChefReservationsMs.Features.Chefs.Enums
{
    public enum CuisineType : byte
    {
        [Description("Cocina Italiana")]
        CocinaItaliana,
        [Description("CocinaCriolla")]
        CocinaCriolla,
        [Description("Cocina Española")]
        CocinaEspañola,
        [Description("Cocina Japonesa")]
        CocinaJaponesa,
        [Description("Cocina Mexicana")]
        CocinaMexicana,
        [Description("Cocina Vegetariana")]
        CocinaVegetariana,
        [Description("Cocina Coreana")]
        CocinaCoreana
    }
}
