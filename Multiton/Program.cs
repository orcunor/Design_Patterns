// See https://aka.ms/new-console-template for more information

Camera nikon = Camera.GetCamera("Nikon");
Camera canon = Camera.GetCamera("Canon");
Camera kodak = Camera.GetCamera("Kodak");
Camera nikon2 = Camera.GetCamera("Nikon");



Console.WriteLine(nikon.Id);
Console.WriteLine(canon.Id);
Console.WriteLine(kodak.Id);
Console.WriteLine(nikon2.Id);

Console.ReadLine();


class Camera // nikon için tek instance , canon için tek instance vb..
{
    public static Dictionary<string, Camera> _cameras = new Dictionary<string,Camera>();

    private static object _lockObject = new object();

    public Guid Id { get; set; }

    private Camera()
    {
       Id = Guid.NewGuid();
    }

    public static Camera GetCamera(string brand)
    {
        lock (_lockObject)
        {
            if (!_cameras.ContainsKey(brand))
            {
                _cameras.Add(brand, new Camera());
            }
        }
        return _cameras[brand]; 
    }

   
}
