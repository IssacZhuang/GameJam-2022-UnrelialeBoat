public class BulletConfig : BaseThingConfig
{
    public float speed;
    public float lifeTime;
}


public class GunConfig : BaseThingConfig
{
    public int magzineSize;
    public BulletConfig bullet;
}
