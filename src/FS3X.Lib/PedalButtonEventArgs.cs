namespace FS3X.Lib
{
    public class PedalButtonEventArgs
    {
        #region Constructors

        internal PedalButtonEventArgs(PedalButton button, PedalButtonStatus status)
        {
            Button = button;
            Status = status;
        }

        #endregion

        #region Properties

        public PedalButton Button { get; }

        public PedalButtonStatus Status { get; }

        #endregion

        #region Cnstants

        public static PedalButtonEventArgs Undefined => new PedalButtonEventArgs(PedalButton.Undefined, PedalButtonStatus.Undefined);

        #endregion
    }
}
