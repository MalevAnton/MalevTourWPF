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
    
    public partial class HotelOfTour
    {
        public int id_HotelOfTour { get; set; }
        public int id_Hotel { get; set; }
        public int id_Tour { get; set; }
    
        public virtual Hotel Hotel { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
