using System.ComponentModel.DataAnnotations;

namespace GalaxiaUniversity.Domain.Core.Repository.Entities
{
    public class Country
    {
        public Country(string name, int population)
        {
            Name = name;
            Population = population;
        }

        [Key]
        public int Id { get; private set; }

        [StringLength(100)]
        public string Name { get; private set; }

        public int Population { get; private set; }
    }
}
