using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine.SceneManagement;

public class FirebaseAuthManager : MonoBehaviour
{
    public TMP_InputField emailField; // E-posta alanı
    public TMP_InputField passwordField; // şifre alanı
    public Button LoginButton; // Giriş düğmesi
    public Button registerButton; // Kayıt düğmesi
    public Button resetPasswordButton; // şifre sıfırlama düğmesi

    private FirebaseAuth auth; // Firebase kimlik doğrulama nesnesi

    
    private void Start()
    {

        //İmleç açık
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;


        // Firebase Kimlik Doğrulama'yı başlat
        auth = FirebaseAuth.DefaultInstance;

        // Giriş düğmesine tıklandığında bir onClick olay dinleyicisi ekle
        LoginButton.onClick.AddListener(Login);
        // Kayıt düğmesine tıklandığında bir onClick olay dinleyicisi ekle
        registerButton.onClick.AddListener(Register);
        // şifre sıfırlama düğmesine tıklandığında bir onClick olay dinleyicisi ekle
        resetPasswordButton.onClick.AddListener(ResetPassword);
    }

    public void Login() // Giriş işlemi
    {
        string email = emailField.text;
        string password = passwordField.text;

        // Kullanıcıyı doğrulamak için Firebase'in SignInWithEmailAndPassword yöntemini çağırın
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("Giriş iptal edildi.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("Giriş sırasında bir hata oluştu: " + task.Exception);
                return;
            }

            // Giriş başarılı
            AuthResult result = task.Result;
            FirebaseUser user = result.User;
            Debug.Log(user.Email + "Olarak giriş yapıldı: " );
        });
    }

    public void Register() // Kayıt işlemi
    {
        string email = emailField.text;
        string password = passwordField.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("Kullanıcı kaydı iptal edildi.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("Kullanıcı kaydı sırasında bir hata oluştu: " + task.Exception);
                return;
            }

            AuthResult result = task.Result;
            FirebaseUser newUser = result.User;
            Debug.Log("Kullanıcı kaydedildi: " + newUser.Email);
        });
    }

    private void ResetPassword() // şifre sıfırlama işlemi
    {
        string email = emailField.text;

        auth.SendPasswordResetEmailAsync(email).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("şifre sıfırlama iptal edildi.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("şifre sıfırlama sırasında bir hata oluştu: " + task.Exception);
                return;
            }

            Debug.Log("şifre sıfırlama e-postası gönderildi: " + email);
        });
    }

    public void LogIn()
    {
        SceneManager.LoadScene(1);
    }
}