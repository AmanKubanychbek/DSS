//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DecisionSupportSystem.DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaskParam
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int TaskId { get; set; }
        public Nullable<int> NameId { get; set; }
    
        public virtual TaskParamName TaskParamName { get; set; }
        public virtual Task Task { get; set; }
    }
}
