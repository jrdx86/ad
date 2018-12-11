package serpis.ad;

import java.sql.PreparedStatement;
import java.sql.SQLException;
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
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(updateSql);
		preparedStatement.setObject(1, categoria.getNombre());
		preparedStatement.setObject(2, categoria.getId());
		return preparedStatement.executeUpdate();
	}
	public static int save(Categoria categoria) throws SQLException{
		if (categoria.getId()==0)
			return insert(categoria);
		else
			return update(categoria);
		
	}
	public static Categoria load(long id) throws SQLException{
		
    	return null;
    }
	
	private static String deleteSql = "delete from categoria where id = ?";
    public static int delete(long id)throws SQLException{
		PreparedStatement preparedStatement = App.getInstance().getConnection().prepareStatement(deleteSql);
		preparedStatement.setObject(1, id);
		return preparedStatement.executeUpdate();
    }
    public static List<Categoria> getAll() throws SQLException{
    	return null;
    }
    
}
