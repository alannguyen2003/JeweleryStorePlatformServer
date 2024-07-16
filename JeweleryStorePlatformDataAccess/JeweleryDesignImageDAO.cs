using JeweleryStorePlatformBusinessObject.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryStorePlatformDataAccess
{
    public class JeweleryDesignImageDAO
    {
        private readonly AppDbContext _context;
        private static JeweleryDesignImageDAO instance;

        public JeweleryDesignImageDAO()
        {
            _context = new AppDbContext();
        }

        public static JeweleryDesignImageDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JeweleryDesignImageDAO();
                }
                return instance;
            }
        }
        public async Task<JeweleryDesignImage> AddNewJeweleryDesignImage(JeweleryDesignImage jeweleryDesignImage)
        {
            _context.Set<JeweleryDesignImage>().Add(jeweleryDesignImage);
            await _context.SaveChangesAsync();
            return jeweleryDesignImage;
        }
    }
}
