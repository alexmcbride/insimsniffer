
namespace InSimSniffer.Library.Packets {
    internal interface ISendable {
        byte ReqI { get; set; }
        byte[] GetBuffer();
    }
}
