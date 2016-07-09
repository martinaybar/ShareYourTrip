using System.Collections.Generic;

namespace ShareYourTrip.Entities.DataModels
{

    /// <summary>
    /// Intereses del usuario. Ej. deportes, viajes, e
    /// </summary>
    public class UserPreference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }

    }

    public enum UserPreferenceEnum
    {
        Viajes = 1,
        Negocios,
        Deportes,
        Tecnologia,
        Historia,
        Emprendimientos,
        Ciencia
    }
}
