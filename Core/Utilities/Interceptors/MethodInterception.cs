using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        // Invocation aslında bizim methodumuz. Çalıştırılmaya çalışılan operasyon demek.
        // Method çalışmadan önce sen çalış diyoruz.
        protected virtual void OnBefore(IInvocation invocation) { }
        // Method çalıştıktan sonra çalış
        protected virtual void OnAfter(IInvocation invocation) { }
        // Method hata verdiğinde sen çalış
        protected virtual void OnException(IInvocation invocation) { }
        // Method başarılı ise sen çalış
        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception)
            {
                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}