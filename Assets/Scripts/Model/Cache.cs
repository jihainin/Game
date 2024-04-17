
namespace MrJi
{
    public class Cache
    {
        public float BGMVolume;

        public float SpecialEfficacyVolume;

        public bool BGMIson;




        public Cache Default()
        {
            this.BGMVolume = 0.2f;
            this.SpecialEfficacyVolume = 1f;
            this.BGMIson = true;
            return this; 
        }
    }
}
