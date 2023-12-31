﻿



using TestZPLPrint;

while (true)
{
    Console.Write("IP:");
    var ip =Console.ReadLine();

    Console.Write("PORT:");
    var port = int.Parse(Console.ReadLine());
    Console.Write("CONTENT:");
    var content = Console.ReadLine();
    if (string.IsNullOrEmpty(content))
        content = "^XA\r\n\r\n^FX Top section with logo, name and address.\r\n^CF0,60\r\n^FO50,50^GB100,100,100^FS\r\n^FO75,75^FR^GB100,100,100^FS\r\n^FO93,93^GB40,40,40^FS\r\n^FO220,50^FDIntershipping, Inc.^FS\r\n^CF0,30\r\n^FO220,115^FD1000 Shipping Lane^FS\r\n^FO220,155^FDShelbyville TN 38102^FS\r\n^FO220,195^FDUnited States (USA)^FS\r\n^FO50,250^GB700,3,3^FS\r\n\r\n^FX Second section with recipient address and permit information.\r\n^CFA,30\r\n^FO50,300^FDJohn Doe^FS\r\n^FO50,340^FD100 Main Street^FS\r\n^FO50,380^FDSpringfield TN 39021^FS\r\n^FO50,420^FDUnited States (USA)^FS\r\n^CFA,15\r\n^FO600,300^GB150,150,3^FS\r\n^FO638,340^FDPermit^FS\r\n^FO638,390^FD123456^FS\r\n^FO50,500^GB700,3,3^FS\r\n\r\n^FX Third section with bar code.\r\n^BY5,2,270\r\n^FO100,550^BC^FD12345678^FS\r\n\r\n^FX Fourth section (the two boxes on the bottom).\r\n^FO50,900^GB700,250,3^FS\r\n^FO400,900^GB3,250,3^FS\r\n^CF0,40\r\n^FO100,960^FDCtr. X34B-1^FS\r\n^FO100,1010^FDREF1 F00B47^FS\r\n^FO100,1060^FDREF2 BL4H8^FS\r\n^CF0,190\r\n^FO470,955^FDCA^FS\r\n\r\n^XZ";

    ZPLAction zplprinter = new ZPLAction().ForIP(ip).WithPort(port);    
    if (zplprinter.SendToZPL(content))
        Console.WriteLine("STAMPATO");
    else
        Console.WriteLine("ERRORE STAMPA");
    Console.ReadKey();
}


