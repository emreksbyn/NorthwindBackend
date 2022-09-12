using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation;
using Ninject.Modules;

namespace Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}