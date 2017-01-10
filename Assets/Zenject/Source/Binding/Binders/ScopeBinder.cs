using System;
using ModestTree;

namespace Zenject
{
    public class ScopeBinder : ConditionBinder
    {
        public ScopeBinder(BindInfo bindInfo)
            : base(bindInfo)
        {
        }

        public ConditionBinder AsSingle()
        {
            return AsSingle(null);
        }

        public ConditionBinder AsSingle(object concreteIdentifier)
        {
            Assert.IsNull(BindInfo.ConcreteIdentifier);

            BindInfo.Scope = ScopeTypes.Singleton;
            BindInfo.ConcreteIdentifier = concreteIdentifier;
            return this;
        }

        internal void FromMethod(object instantiateIPositionEntity)
        {
            throw new NotImplementedException();
        }

        public ConditionBinder AsCached()
        {
            BindInfo.Scope = ScopeTypes.Cached;
            return this;
        }

        // Note that this is the default so it's not necessary to call this
        public ConditionBinder AsTransient()
        {
            BindInfo.Scope = ScopeTypes.Transient;
            return this;
        }
    }
}

