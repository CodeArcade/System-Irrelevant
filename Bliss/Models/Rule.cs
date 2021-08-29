using Bliss.Component.Sprites.Office.Documents;
using System;

namespace Bliss.Models
{
    public enum DocumentType
    {
        Application,
        Classified,
        Contract,
        Letter,
        Paycheck,
        All
    }

    public class Rule
    {
        public string Description { get; set; }
        public DocumentType DocumentType { get; set; }
        public Func<BaseDocument, bool> Validate { get; set; }
        public bool  ShowOnStickyNote { get; set; } = true;

        public Rule(DocumentType documentType)
        {
            DocumentType = documentType;
        }
    }
}
