public class Tensor
{
    private readonly double[] _data; // Flattened array to store tensor data

    // Public properties
    public int[] Shape { get; private set; } // Returns the shape of the tensor
    public int Rank => Shape.Length; // Returns the rank (number of dimensions)
    public int Size => _data.Length; // Returns the total number of elements

    // Constructor
    public Tensor(int[] shape)
    {
        if (shape == null || shape.Length == 0)
        {
            throw new ArgumentException("Shape must not be null or empty.");
        }

        Shape = shape;
        _data = new double[CalculateTotalSize(shape)];
    }

    // Constructor to initialize with data
    public Tensor(int[] shape, double[] data)
    {
        if (shape == null || shape.Length == 0)
        {
            throw new ArgumentException("Shape must not be null or empty.");
        }

        if (data == null || data.Length != CalculateTotalSize(shape))
        {
            throw new ArgumentException("Data length must match the total size of the shape.");
        }

        Shape = shape;
        _data = data;
    }

    // Helper method to calculate total size from shape
    private int CalculateTotalSize(int[] shape)
    {
        int size = 1;
        foreach (int dim in shape)
        {
            if (dim <= 0)
            {
                throw new ArgumentException("All dimensions must be positive.");
            }

            size *= dim;
        }

        return size;
    }

    // Indexer to access tensor elements
    public double this[params int[] indices]
    {
        get
        {
            ValidateIndices(indices);
            int flatIndex = CalculateFlatIndex(indices);
            return _data[flatIndex];
        }
        set
        {
            ValidateIndices(indices);
            int flatIndex = CalculateFlatIndex(indices);
            _data[flatIndex] = value;
        }
    }

    // Helper method to validate indices
    private void ValidateIndices(int[] indices)
    {
        if (indices == null || indices.Length != Rank)
        {
            throw new ArgumentException("Indices must match the tensor rank.");
        }

        for (int i = 0; i < indices.Length; i++)
        {
            if (indices[i] < 0 || indices[i] >= Shape[i])
            {
                throw new IndexOutOfRangeException($"Index {indices[i]} is out of range for dimension {i}.");
            }
        }
    }

    // Helper method to calculate flat index from multidimensional indices
    private int CalculateFlatIndex(int[] indices)
    {
        int flatIndex = 0;
        int stride = 1;
        for (int i = Rank - 1; i >= 0; i--)
        {
            flatIndex += indices[i] * stride;
            stride *= Shape[i];
        }

        return flatIndex;
    }

    // Method to reshape the tensor
    public void Reshape(int[] newShape)
    {
        int newSize = CalculateTotalSize(newShape);
        if (newSize != Size)
        {
            throw new ArgumentException("New shape must have the same total size as the original shape.");
        }

        Shape = newShape;
    }

    // Element-wise addition (parallel)
    public Tensor Add(Tensor other)
    {
        return ElementWiseOperationParallel(other, (a, b) => a + b);
    }

    // Element-wise subtraction (parallel)
    public Tensor Subtract(Tensor other)
    {
        return ElementWiseOperationParallel(other, (a, b) => a - b);
    }

    // Element-wise multiplication (parallel)
    public Tensor Multiply(Tensor other)
    {
        return ElementWiseOperationParallel(other, (a, b) => a * b);
    }

    // Element-wise division (parallel)
    public Tensor Divide(Tensor other)
    {
        return ElementWiseOperationParallel(other, (a, b) => a / b);
    }

    // Helper method for parallel element-wise operations
    private Tensor ElementWiseOperationParallel(Tensor other, Func<double, double, double> operation)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        if (!Shape.SequenceEqual(other.Shape))
        {
            throw new ArgumentException("Tensors must have the same shape for element-wise operations.");
        }

        double[] resultData = new double[Size];

        // Parallelize the loop
        _ = Parallel.For(0, Size, i => resultData[i] = operation(_data[i], other._data[i]));

        return new Tensor(Shape, resultData);
    }

    // Override ToString for better visualization
    public override string ToString()
    {
        return $"Tensor(Shape=[{string.Join(", ", Shape)}], Data=[{string.Join(", ", _data)}])";
    }
}