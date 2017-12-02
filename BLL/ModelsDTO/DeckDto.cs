using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.ModelsDTO
{
    public class DeckDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Public { get; set; }

        public DeckDto()
        {
        }

        public DeckDto(int id, string name, string description, bool @public)
        {
            Id = id;
            Name = name;
            Description = description;
            Public = @public;
        }
    }
}