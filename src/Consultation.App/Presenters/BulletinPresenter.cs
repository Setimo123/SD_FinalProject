using Consultation.App.Views.IViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.App.Presenters
{
    public class BulletinPresenter
    {
        private readonly IBulletinView _view;
        public BulletinPresenter(IBulletinView view)
        {
            _view = view;
            //_view.LoadBulletin += LoadBulletin;
        }
    }
}
