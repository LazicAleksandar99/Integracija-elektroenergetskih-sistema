//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FTN {
    using System;
    using FTN;
    
    
    /// The motivation of an act.
    public class Reason : IdentifiedObject {
        
        /// The motivation of an act in coded form.
        private string cim_code;
        
        private const bool isCodeMandatory = false;
        
        private const string _codePrefix = "cim";
        
        /// The textual explanation corresponding to the reason code.
        private string cim_text;
        
        private const bool isTextMandatory = false;
        
        private const string _textPrefix = "cim";
        
        public virtual string Code {
            get {
                return this.cim_code;
            }
            set {
                this.cim_code = value;
            }
        }
        
        public virtual bool CodeHasValue {
            get {
                return this.cim_code != null;
            }
        }
        
        public static bool IsCodeMandatory {
            get {
                return isCodeMandatory;
            }
        }
        
        public static string CodePrefix {
            get {
                return _codePrefix;
            }
        }
        
        public virtual string Text {
            get {
                return this.cim_text;
            }
            set {
                this.cim_text = value;
            }
        }
        
        public virtual bool TextHasValue {
            get {
                return this.cim_text != null;
            }
        }
        
        public static bool IsTextMandatory {
            get {
                return isTextMandatory;
            }
        }
        
        public static string TextPrefix {
            get {
                return _textPrefix;
            }
        }
    }
}
