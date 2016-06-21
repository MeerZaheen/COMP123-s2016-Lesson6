using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLayerProject
{
    public class Grid : List<string>
    {
        // PRIVATE INSTANCE VARIABLES ++++++++++++++++++++++++++++++++++++++++++++++

        private int _width;
        private int _height;

        // PUBLIC PROPERTIES +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public int Height
        {
            get
            {
                return this._height;
            }

            set
            {
                this._height = value;
            }
        }

        public int Width
        {
            get
            {
                return this._width;
            }

            set
            {
                this._width = value;
            }
        }

        // CONSTRUCTORS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * This constructor takes two parameters: width and height that define the size
         * of the grid
         * </summary>
         * 
         * @constructor Grid
         * @param {int} width
         * @param {int} height
         */
        public Grid(int width = 2, int height = 2)
        {
            if (width < 2)
            {
                width = 2;
            }

            if (height < 2)
            {
                height = 2;
            }

            this.Width = width;
            this.Height = height;

            // Build the grid
            this._build();
        }


        // PRIVATE METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * This utility method builds the grid
         * </summary>
         * 
         * @private
         * @method _build
         * @returns {void}
         */
        private void _build()
        {
            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    this.Add(".");
                }
            }
        }

        /**
         * <summary>
         * This utility method converts x and y coordinates to Grid position
         * </summary>
         * 
         * @method _convertToGridPosition
         * @param {float} x
         * @param {float} y
         * @returns {int}
         */
        private int _convertToGridPosition(float x, float y)
        {
            int col = Convert.ToInt32(x);
            int row = Convert.ToInt32(y);
            int position = (row * (this.Width - 1)) + col;

            return position;
        }

        // OVERRIDEN METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public override string ToString()
        {
            string gridString = "";

            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    gridString += this[(row * (this.Width - 1)) + col];
                }
                gridString += "\n";
            }

            return gridString;
        }

        // PUBLIC METHODS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * This method adds a GameObject to the grid
         * </summary>
         * 
         * @method AddChild
         * @param {GameObject} gameObject
         * @returns {void}
         */
        public void AddChild(GameObject gameObject)
        {
            int position = this._convertToGridPosition(gameObject.Position.x, gameObject.Position.y);

            this[position] = (gameObject.GetType().Name == "Player") ? "p" : "e";
        }

        /**
         * <summary>
         * This method moves a GameObject from one position to another on the Grid
         * </summary>
         * 
         * @method MoveChild
         * @param {GameObject} gameObject
         * @param {Vector2} position
         * @returns {void}
         */
        public void MoveChild(GameObject gameObject, Vector2 position)
        {
            int currentPosition = this._convertToGridPosition(gameObject.Position.x, gameObject.Position.y);
            Console.WriteLine("Current: " + currentPosition);

            int newPosition = this._convertToGridPosition(position.x, position.y);
            Console.WriteLine("New: " + newPosition);

            this[newPosition] = this[currentPosition];
            this[currentPosition] = ".";
        }
    }
}
