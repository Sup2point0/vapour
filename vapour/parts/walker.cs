namespace Vapour.Effects;


/// An entity that moves along the pixels of an effect matrix. Functionality is added through deriving from the class and implementing `.Update()`, which is called every frame.
///
/// Position is bound within dimensions of effect matrix. Note cords are 1-indexed, i.e. bottom-left is (1, 1) and top-right is (size, size).
public class Walker<TMatrix> where TMatrix : EffectMatrix
{
    public TMatrix source;

    private int _x;
    public int x {
        get => _x;
        set {
            _x = value;

            if (_x < 1) {
                _x = this.source.width;
            }
            else if (_x > this.source.width) {
                this._x = 1;
            }
        }
    }

    private int _y;
    public int y {
        get => _y;
        set {
            _y = value;

            if (_y < 1) {
                _y = this.source.height;
            }
            else if (_y > this.source.height) {
                this._y = 1;
            }
        }
    }

    public (int, int) xy {
         get => (this.x, this.y);
    }

    public Walker(TMatrix source, (int x, int y))
    {
        this.source = source;
        this.x = x;
        this.y = y;
    }

    public virtual void Update()
    {
        RandomStep();
    }

    /// <summary>
    /// Take a step of 1 in either the x or y direction.
    /// </summary>
    public virtual void RandomStep()
    {
        // decide x or y
        var direction = Utils.Rand.Binary();

        if (direction == 0) {
             this.x += Utils.Rand.Direction();
        } else {
             this.y += Utils.Rand.Direction();
        }
    }
}
