using System;

namespace FooOffer.BusinessLogic.Common.Attributes
{
    public class AutoRegisterServiceAttribute : Attribute
    {
        public ActivationType Activation { get; set; } = ActivationType.InstancePerDependency;
        public int RegistrationOrder { get; set; } = int.MaxValue;

        public AutoRegisterServiceAttribute(ActivationType activation = ActivationType.InstancePerDependency)
        {
            Activation = activation;
        }

        public AutoRegisterServiceAttribute(int registrationOrder)
        {
            RegistrationOrder = registrationOrder;
        }

        public AutoRegisterServiceAttribute(ActivationType activation, int registrationOrder)
        {
            Activation = activation;
            RegistrationOrder = registrationOrder;
        }

        public enum ActivationType
        {
            InstancePerDependency,
            SingleInstance,
            InstancePerLifetimeScope,
            Transient
        }
    }
}