using MySql.Data.MySqlClient;

public abstract class TableGateway
{
    protected readonly MySqlConnection Connection;

    protected TableGateway(MySqlConnection connection)
    {
        Connection = connection;
    }
}