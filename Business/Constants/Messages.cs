using System.ComponentModel;

namespace Business.Constants
{
    public enum Messages
    {
        [Description("Başarıyla eklendi")]
        AddingSuccessful = 1,

        [Description("Başarıyla güncellendi")]
        UpdatingSuccessful = 2,

        [Description("Başarıyla silindi")]
        DeletingSuccessful = 3,

        [Description("Ürün başarıyla eklendi")]
        ProductAdded = 4,

        [Description("Ürün başarıyla silindi")]
        ProductDeleted = 5,

        [Description("Ürün başarıyla güncellendi")]
        ProductUpdated = 6,

        [Description("Kategori başarıyla eklendi")]
        CategoryAdded = 7,

        [Description("Kategori başarıyla silindi")]
        CategoryDeleted = 8,

        [Description("Kategori başarıyla güncellendi")]
        CategoryUpdated = 9,

        [Description("Kullanıcı bulunamadı")]
        UserNotFound = 10,

        [Description("Şifre hatalı")]
        PasswordError = 11,

        [Description("Sisteme giriş başarılı")]
        SuccessfulLogin = 12,

        [Description("Bu kullanıcı zaten mevcut")]
        UserAlreadyExists = 13,

        [Description("Kullanıcı başarıyla kaydedildi")]
        UserRegistered = 14,

        [Description("Access Token başarıyla oluşturuldu")]
        AccessTokenCreated = 15,

        [Description("Yetkiniz yok")]
        AuthorizationDenied = 16,

        [Description("Ürün ismi zaten mevcut")]
        ProductNameAlreadyExists = 17,

        [Description("Kategori uygun değil.")]
        CategoryIsNotEnabled = 18,

        [Description("Kategori limiti asildi.")]
        CategoryLimitExceeded = 19
    }
}