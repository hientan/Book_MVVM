using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Utils
{
    public class Localization
    {
        /// <summary>
        /// instance.
        /// </summary>
        private static Localization instance;
        /// <summary>
        /// resource
        /// </summary>
        ResourceManager resource = new ResourceManager("BookManagement.Properties.Resources", Assembly.GetExecutingAssembly());
        /// <summary>
        /// Prevents a default instance of the Localization class from being created
        /// </summary>
        private Localization()
        {
            // Do nothing.
        }
        public static Localization Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Localization();
                }
                return instance;
            }
        }
        /// <summary>
        /// Get string
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetString(string key)
        {
            return resource.GetString(key);
        }
    }
}
