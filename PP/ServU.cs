//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PP
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServU
    {
        public int ID { get; set; }
        public Nullable<int> ModelServ { get; set; }
        public string SerNum { get; set; }
        public string InvNum { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> DateState { get; set; }
    
        public virtual ModelSer ModelSer { get; set; }
        public virtual Stat Stat { get; set; }
    }
}