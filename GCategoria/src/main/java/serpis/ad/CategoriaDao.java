package serpis.ad;

import java.math.BigInteger;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
//interaccion con base de datos
public class CategoriaDao {
	
	private static String insertSql = "insert into categoria (nombre) values (?)";
	public static int insert (Categoria categoria) throws SQLException {
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(insertSql);
		preparedStatement.setObject(1, categoria.getNombre());
		return preparedStatement.executeUpdate();//devuelve numero de filas afectadas
	}
	private static String updateSql = "update categoria set nombre = ? where id = ?";
	public static int update(Categoria categoria) throws SQLException {		
//		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(updateSql);
//		preparedStatement.setObject(1, categoria.getNombre());
//		preparedStatement.setObject(2, categoria.getId());
//		return preparedStatement.executeUpdate();
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(updateSql);
		preparedStatement.setObject(1, categoria.getNombre());
		int rowCount = preparedStatement.executeUpdate();
		preparedStatement.close();
		return rowCount;
		
	}
	
	public static int save(Categoria categoria) throws SQLException{
		if (categoria.getId()==0)
			return insert(categoria);
		else
			return update(categoria);
		
	}
	private static String loadSQL = "select id, nombre from categoria where id =?";
	public static Categoria load(long id) throws SQLException{
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(loadSQL);
		preparedStatement.setObject(1, id);		
		ResultSet resultSet = preparedStatement.executeQuery();
		Categoria categoria = new Categoria();
		resultSet.next();
		categoria.setId(resultSet.getLong("id"));
		categoria.setNombre((String)resultSet.getObject("nombre"));
		preparedStatement.close();
		return categoria;		
    }
	
	private static String deleteSql = "delete from categoria where id = ?";
    public static int delete(long id)throws SQLException{
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(deleteSql);
		preparedStatement.setObject(1, id);
		return preparedStatement.executeUpdate();
    }
    
    
    //List es una interface por lo que no se puede crear objetos, los objetos solo se crean en clases concretas
    private static final String selectAll = "select id, nombre from categoria";
    public static List<Categoria> getAll() throws SQLException{
       	List<Categoria> categorias = new ArrayList<>();
    	Statement statement = App.getInstance().getConnection().createStatement();
    	ResultSet resultSet = statement.executeQuery(selectAll);
    	while(resultSet.next()) {
	    	Categoria categoria = new Categoria();
           //Categoria.setId( ((BigInteger)resultSet.getObject("id")).longValue() );
	    	categoria.setId(resultSet.getLong("id"));
	    	categoria.setNombre((String)resultSet.getObject("nombre"));
	    	categorias.add(categoria);
    	}
    		statement.close();
	    	return categorias;
    	
    }
}
