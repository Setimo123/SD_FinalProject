using Consultation.App.Views.Controls.ConsultationManagement;
using System;
using System.Collections.Generic;

namespace Consultation.App.Views.IViews
{
    public interface IConsultationView
    {
        event EventHandler ShowActiveEvent;
        event EventHandler ShowArchivedEvent;
        event EventHandler RefreshConsultationsEvent;

        event EventHandler<ConsultationData> ArchiveRequested;
        event EventHandler<ConsultationData> RestoreRequested;
        event EventHandler<ConsultationData> DeleteRequested;

        void LoadActiveConsultations(List<ConsultationData> consultations);
        void LoadArchivedConsultations(List<ConsultationData> consultations);
        void SwitchToArchivedView();
        void SwitchToActiveView();
    }
}
