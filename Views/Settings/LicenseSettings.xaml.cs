using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SHEndevour.Utilities;
using UserControl = System.Windows.Controls.UserControl;
using SHEndevour.Models.License;
using MessageBox = System.Windows.MessageBox;
using System.ComponentModel;

namespace SHEndevour.Views.Settings
{
    /// <summary>
    /// Lógica de interacción para LicenseSettings.xaml
    /// </summary>
    public partial class LicenseSettings : UserControl
    {

        private readonly AppDbContext _dbContext;
        private LicenseModel _currentLicense;
        public LicenseSettings()
        {
            InitializeComponent();
            GenerateInstallationCode();
            _dbContext = new AppDbContext();
            LoadLicenseData(); // Cargar datos al iniciar
        }



        // Genera el Código de Instalación basado en la fecha de creación de la carpeta raíz
        private void GenerateInstallationCode()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DateTime creationDate = Directory.GetCreationTime(appDirectory);

            DateTime referenceDate = new DateTime(2020, 1, 1);
            double uniqueNumber = (creationDate - referenceDate).TotalSeconds;

            // Genera el código de instalación con Random y lo muestra en el TextBox
            Random random = new Random((int)uniqueNumber);
            char[] code = new char[8];
            for (int i = 0; i < 8; i++)
            {
                code[i] = (char)random.Next(65, 91); // Letras A-Z
            }
            CodigoInstalacionTXBX.Text = new string(code);
        }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =



        // Cargar datos existentes (si existen)
        private void LoadLicenseData()
        {
            _currentLicense = _dbContext.LicenseTable.FirstOrDefault();
            if (_currentLicense != null)
            {
                PopulateFields();
            }
        }

        // Rellenar los campos con los datos de la licencia
        private void PopulateFields()
        {
            NombreNegocioTbx.Text = _currentLicense.NombreNegocio;
            NombreClienteTbx.Text = _currentLicense.NombreCliente;
            ContactoTbx.Text = _currentLicense.NumeroTelefono;
            EmailTbx.Text = _currentLicense.CorreoElectronico;
            RazonSocialTbx.Text = _currentLicense.RazonSocial;
            NombreComercialTbx.Text = _currentLicense.NombreComercial;
            RegimenFiscalTbx.Text = _currentLicense.RegimenFiscal;
            RFCTbx.Text = _currentLicense.RFC;
            DomicilioTbx.Text = _currentLicense.DomicilioCompleto;
            CodigoPostalTbx.Text = _currentLicense.CodigoPostal;
            CodigoInstalacionTXBX.Text = _currentLicense.CodigoInstalacion;
            ClaveInstalacionTXBX.Text = _currentLicense.ClaveInstalacion;
            FechaLicenciaTXBX.SelectedDate = _currentLicense.FechaLicencia;
            ClaveLicenciaTXBX.Text = _currentLicense.ClaveLicencia;
        }

        // Evento de guardar datos
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = ValidateLicense(); // Verifica licencia antes de guardar

            if (_currentLicense == null)
            {
                _currentLicense = new LicenseModel();
                _dbContext.LicenseTable.Add(_currentLicense);
            }

            PopulateLicenseModel(); // Rellenar modelo con los datos ingresados
            _dbContext.SaveChanges();

            if (isValid)
            {
                MessageBox.Show("Licencia guardada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Las credenciales son erróneas, pero los datos se han guardado.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Validación de la licencia e instalación
        private bool ValidateLicense()
        {
            string installationCode = CodigoInstalacionTXBX.Text;
            string rfc = RFCTbx.Text;

            long seed1 = CalculateSeed1(installationCode);
            long rfcSeed = GenerateRFCSeed(rfc);

            if (!DateTime.TryParse(FechaLicenciaTXBX.Text, out DateTime licenseDate))
            {
                MessageBox.Show("Fecha de licencia inválida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false; // Retorna false si hay error, pero no detendrá el guardado
            }

            long seed2 = GenerateSeed2(seed1, rfcSeed, licenseDate);
            string generatedLicenseKey = GenerateLicenseKey(seed2);

            if (ClaveLicenciaTXBX.Text != generatedLicenseKey || ClaveInstalacionTXBX.Text != GenerateInstallationKey(seed1))
            {
                MessageBox.Show("Licencia o clave de instalación inválidas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false; // Retorna false si hay error, pero no detendrá el guardado
            }

            return true; // Retorna true si todo es válido
        }

        // Rellenar el modelo de licencia con los datos ingresados
        private void PopulateLicenseModel()
        {
            _currentLicense.NombreNegocio = NombreNegocioTbx.Text;
            _currentLicense.NombreCliente = NombreClienteTbx.Text;
            _currentLicense.NumeroTelefono = ContactoTbx.Text;
            _currentLicense.CorreoElectronico = EmailTbx.Text;
            _currentLicense.RazonSocial = RazonSocialTbx.Text;
            _currentLicense.NombreComercial = NombreComercialTbx.Text;
            _currentLicense.RegimenFiscal = RegimenFiscalTbx.Text;
            _currentLicense.RFC = RFCTbx.Text;
            _currentLicense.DomicilioCompleto = DomicilioTbx.Text;
            _currentLicense.CodigoPostal = CodigoPostalTbx.Text;
            _currentLicense.CodigoInstalacion = CodigoInstalacionTXBX.Text;
            _currentLicense.ClaveInstalacion = ClaveInstalacionTXBX.Text;

            
            // Guardar la fecha seleccionada
            if (FechaLicenciaTXBX.SelectedDate.HasValue)
            {
                _currentLicense.FechaLicencia = FechaLicenciaTXBX.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Por favor selecciona una fecha de licencia.", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;  // Salimos si no se selecciona una fecha válida
            }

            _currentLicense.ClaveLicencia = ClaveLicenciaTXBX.Text;
        }

        // Algoritmos de generación de semillas y claves
        private long CalculateSeed1(string installationCode)
        {
            long seed1 = 0;
            for (int i = 0; i < installationCode.Length; i++)
            {
                int asciiValue = installationCode[i] - 64;
                seed1 += (long)Math.Pow(asciiValue, i + 1);
            }
            return seed1;
        }

        private long GenerateSeed2(long seed1, long rfcSeed, DateTime licenseDate)
        {
            DateTime referenceDate = new DateTime(2020, 1, 1);
            double secondsInterval = (licenseDate - referenceDate).TotalSeconds;
            return seed1 + rfcSeed + (long)secondsInterval;
        }

        private long GenerateRFCSeed(string rfc)
        {

            if (string.IsNullOrEmpty(rfc))
            {
                return 0; // Devolver un valor predeterminado si el RFC está vacío
            }

            string truncatedRfc = rfc.Length > 11 ? rfc.Substring(0, 11) : rfc;
            StringBuilder seedBuilder = new StringBuilder();

            foreach (char c in truncatedRfc.ToUpper())
            {
                int result = char.IsLetter(c) ? (c - 48) % 10 : c - '0';
                seedBuilder.Append(result);
            }

            return long.Parse(seedBuilder.ToString());
        }

        private string GenerateLicenseKey(long seed2)
        {
            Random random = new Random((int)(seed2 % int.MaxValue));
            char[] key = new char[8];
            for (int i = 0; i < 8; i++)
            {
                key[i] = (char)random.Next(65, 91); // Letras A-Z
            }
            return new string(key);
        }

        private string GenerateInstallationKey(long seed1)
        {
            Random random = new Random((int)seed1);
            char[] key = new char[8];
            for (int i = 0; i < 8; i++)
            {
                key[i] = (char)random.Next(65, 91);
            }
            return new string(key);
        }












    }
}
