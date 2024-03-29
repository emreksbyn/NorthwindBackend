﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType.SendMessages());
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Reflection yöntemiyle bir instance üretiyoruz.Productvalidator' u new lemiş olduk
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            // public class ProductValidator : AbstractValidator<Product> asagidaki kod ile buradaki Product a ulasiyoruz.
            // ProductValidator' in base classina ulas neyi generic olarak almis (Product/Category/..)
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            // invocation methodu temsil eder. --> public IResult Add(Product product)/...
            // Method daki entity ile Validator daki entity esit olanlari al.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}