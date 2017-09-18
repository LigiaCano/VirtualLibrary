using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using VirtualLibrary.Models;

namespace VirtualLibrary.Mapping
{
    public class BookMap : ClassMapping<Book>
    {
        public BookMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.GuidComb));
            Property(x => x.Title);
            Property(x => x.Author);
            Property(x => x.Genre);
        }

    }
}