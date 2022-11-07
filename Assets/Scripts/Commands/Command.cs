public abstract class Command {
    public abstract void Do(Cube cube);
    public abstract void Undo(Cube cube);
}