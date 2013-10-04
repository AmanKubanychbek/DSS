//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DecisionSupportSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Combination
    {
        public Combination()
        {
            this.ParameterValues = new HashSet<ParameterValue>();
        }
    
        public int Id { get; set; }
        public int ActionId { get; set; }
        public int EventId { get; set; }
        public int TaskId { get; set; }
    
        public virtual Action Action { get; set; }
        public virtual Event Event { get; set; }
        public virtual Task Task { get; set; }
        public virtual ICollection<ParameterValue> ParameterValues { get; set; }
        public virtual ConditionalProfit ConditionalProfit { get; set; }
        public virtual WeightedProfit WeightedProfit { get; set; }
        public virtual ConditionalOpportunityLoss ConditionalOpportunityLoss { get; set; }
        public virtual WeightedOpportunityLoss WeightedOpportunityLoss { get; set; }
    }
}
