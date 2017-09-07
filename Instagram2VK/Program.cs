using Instagram2VK.Presenters;
using Instagram2VK.Services;
using Instagram2VK.Services.Instagram;
using Instagram2VK.Services.Message;
using Instagram2VK.Services.VK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instagram2VK
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Main form = new Main();
            IMainService mainService = new MainService();
            IMessageService messageService = new MessageService();
            IVkService vkService = new VkService();
            IInstagramService instagramService = new InstagramService();

            MainPresenter presenter = new MainPresenter(form, instagramService, mainService, vkService, messageService);

            Application.Run(form);
        }
    }
}
