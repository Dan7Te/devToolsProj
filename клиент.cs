//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace курсовая
{
    using System;
    using System.Collections.Generic;
    
    public partial class клиент
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public клиент()
        {
            this.Заказы = new HashSet<Заказы>();
        }
    
        public int id_клиента { get; set; }
        public string адрес { get; set; }
        public string фио { get; set; }
        public string пол { get; set; }
        public Nullable<System.DateTime> дата_рождения { get; set; }
        public Nullable<int> категория_клиента_id { get; set; }
        public string номер_счета { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заказы> Заказы { get; set; }
        public virtual категория_клиента категория_клиента { get; set; }
        public virtual счета счета { get; set; }
    }
}
