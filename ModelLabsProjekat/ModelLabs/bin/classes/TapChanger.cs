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
    
    
    /// Mechanism for changing transformer winding tap positions.
    public class TapChanger : PowerSystemResource {
        
        /// Highest possible tap step position, advance from neutral
        private System.Int32? cim_highStep;
        
        private const bool isHighStepMandatory = false;
        
        private const string _highStepPrefix = "cim";
        
        /// For an LTC, the delay for initial tap changer operation (first step change)
        private System.Single? cim_initialDelay;
        
        private const bool isInitialDelayMandatory = false;
        
        private const string _initialDelayPrefix = "cim";
        
        /// Lowest possible tap step position, retard from neutral
        private System.Int32? cim_lowStep;
        
        private const bool isLowStepMandatory = false;
        
        private const string _lowStepPrefix = "cim";
        
        /// Specifies whether or not a TapChanger has load tap changing capabilities.
        private System.Boolean? cim_ltcFlag;
        
        private const bool isLtcFlagMandatory = false;
        
        private const string _ltcFlagPrefix = "cim";
        
        /// The neutral tap step position for this winding.
        private System.Int32? cim_neutralStep;
        
        private const bool isNeutralStepMandatory = false;
        
        private const string _neutralStepPrefix = "cim";
        
        /// Voltage at which the winding operates at the neutral tap setting.
        private System.Single? cim_neutralU;
        
        private const bool isNeutralUMandatory = false;
        
        private const string _neutralUPrefix = "cim";
        
        /// The tap step position used in "normal" network operation for this winding. For a "Fixed" tap changer indicates the current physical tap setting.
        private System.Int32? cim_normalStep;
        
        private const bool isNormalStepMandatory = false;
        
        private const string _normalStepPrefix = "cim";
        
        /// Specifies the default regulation status of the TapChanger.  True is regulating.  False is not regulating.
        private System.Boolean? cim_regulationStatus;
        
        private const bool isRegulationStatusMandatory = false;
        
        private const string _regulationStatusPrefix = "cim";
        
        /// For an LTC, the delay for subsequent tap changer operation (second and later step changes)
        private System.Single? cim_subsequentDelay;
        
        private const bool isSubsequentDelayMandatory = false;
        
        private const string _subsequentDelayPrefix = "cim";
        
        public virtual int HighStep {
            get {
                return this.cim_highStep.GetValueOrDefault();
            }
            set {
                this.cim_highStep = value;
            }
        }
        
        public virtual bool HighStepHasValue {
            get {
                return this.cim_highStep != null;
            }
        }
        
        public static bool IsHighStepMandatory {
            get {
                return isHighStepMandatory;
            }
        }
        
        public static string HighStepPrefix {
            get {
                return _highStepPrefix;
            }
        }
        
        public virtual float InitialDelay {
            get {
                return this.cim_initialDelay.GetValueOrDefault();
            }
            set {
                this.cim_initialDelay = value;
            }
        }
        
        public virtual bool InitialDelayHasValue {
            get {
                return this.cim_initialDelay != null;
            }
        }
        
        public static bool IsInitialDelayMandatory {
            get {
                return isInitialDelayMandatory;
            }
        }
        
        public static string InitialDelayPrefix {
            get {
                return _initialDelayPrefix;
            }
        }
        
        public virtual int LowStep {
            get {
                return this.cim_lowStep.GetValueOrDefault();
            }
            set {
                this.cim_lowStep = value;
            }
        }
        
        public virtual bool LowStepHasValue {
            get {
                return this.cim_lowStep != null;
            }
        }
        
        public static bool IsLowStepMandatory {
            get {
                return isLowStepMandatory;
            }
        }
        
        public static string LowStepPrefix {
            get {
                return _lowStepPrefix;
            }
        }
        
        public virtual bool LtcFlag {
            get {
                return this.cim_ltcFlag.GetValueOrDefault();
            }
            set {
                this.cim_ltcFlag = value;
            }
        }
        
        public virtual bool LtcFlagHasValue {
            get {
                return this.cim_ltcFlag != null;
            }
        }
        
        public static bool IsLtcFlagMandatory {
            get {
                return isLtcFlagMandatory;
            }
        }
        
        public static string LtcFlagPrefix {
            get {
                return _ltcFlagPrefix;
            }
        }
        
        public virtual int NeutralStep {
            get {
                return this.cim_neutralStep.GetValueOrDefault();
            }
            set {
                this.cim_neutralStep = value;
            }
        }
        
        public virtual bool NeutralStepHasValue {
            get {
                return this.cim_neutralStep != null;
            }
        }
        
        public static bool IsNeutralStepMandatory {
            get {
                return isNeutralStepMandatory;
            }
        }
        
        public static string NeutralStepPrefix {
            get {
                return _neutralStepPrefix;
            }
        }
        
        public virtual float NeutralU {
            get {
                return this.cim_neutralU.GetValueOrDefault();
            }
            set {
                this.cim_neutralU = value;
            }
        }
        
        public virtual bool NeutralUHasValue {
            get {
                return this.cim_neutralU != null;
            }
        }
        
        public static bool IsNeutralUMandatory {
            get {
                return isNeutralUMandatory;
            }
        }
        
        public static string NeutralUPrefix {
            get {
                return _neutralUPrefix;
            }
        }
        
        public virtual int NormalStep {
            get {
                return this.cim_normalStep.GetValueOrDefault();
            }
            set {
                this.cim_normalStep = value;
            }
        }
        
        public virtual bool NormalStepHasValue {
            get {
                return this.cim_normalStep != null;
            }
        }
        
        public static bool IsNormalStepMandatory {
            get {
                return isNormalStepMandatory;
            }
        }
        
        public static string NormalStepPrefix {
            get {
                return _normalStepPrefix;
            }
        }
        
        public virtual bool RegulationStatus {
            get {
                return this.cim_regulationStatus.GetValueOrDefault();
            }
            set {
                this.cim_regulationStatus = value;
            }
        }
        
        public virtual bool RegulationStatusHasValue {
            get {
                return this.cim_regulationStatus != null;
            }
        }
        
        public static bool IsRegulationStatusMandatory {
            get {
                return isRegulationStatusMandatory;
            }
        }
        
        public static string RegulationStatusPrefix {
            get {
                return _regulationStatusPrefix;
            }
        }
        
        public virtual float SubsequentDelay {
            get {
                return this.cim_subsequentDelay.GetValueOrDefault();
            }
            set {
                this.cim_subsequentDelay = value;
            }
        }
        
        public virtual bool SubsequentDelayHasValue {
            get {
                return this.cim_subsequentDelay != null;
            }
        }
        
        public static bool IsSubsequentDelayMandatory {
            get {
                return isSubsequentDelayMandatory;
            }
        }
        
        public static string SubsequentDelayPrefix {
            get {
                return _subsequentDelayPrefix;
            }
        }
    }
}
