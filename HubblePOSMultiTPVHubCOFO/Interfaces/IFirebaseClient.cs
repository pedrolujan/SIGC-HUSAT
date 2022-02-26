using HubFirebase.Models;

namespace HubFirebase
{
    public interface IFirebaseClient
    {
        void StatusChangeFirebase(GenericResponse<dynamic> firebaseEvent);
        /*
        void FuellingPointModeOperationChanged(FuellingPointModeOperationChangedArgs args);
        void FuellingPointSuppliesAnulated(FuellingPointSuppliesAnulatedArgs args);
        void OperatorChanged(OperatorChangedArgs args);
        void InitialOperatorTpv(List<OperatorChangedArgs> args);

        /// <summary>
        /// Metodo Generico, que envía una señal a los Tpvs dentro de su misma red,que representa que hubo un cambio en el Tpv que dispara la señal.
        /// </summary>
        /// <param name="args"></param>
        void NotifyGenericChanges(NotifyGenericChangesArgs args);
        */
    }
}
