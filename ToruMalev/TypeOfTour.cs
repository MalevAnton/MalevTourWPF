//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToruMalev
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypeOfTour
    {
        public int id { get; set; }
        public int id_Tour { get; set; }
        public int id_Type { get; set; }
    
        public virtual Tour Tour { get; set; }
        public virtual Type Type { get; set; }
    }
}