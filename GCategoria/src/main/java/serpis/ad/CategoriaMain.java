package serpis.ad;

import java.util.List;
import java.util.Scanner;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.ArrayList;

public class CategoriaMain {
	
	
    private static boolean exit = false;
	public static void main(String[] args) throws SQLException {
		App.getInstance().setConnection(DriverManager.getConnection("jdbc:mysql;/localhost/dbprueba","root","sistemas"));
		Menu.create("Menú Categoría")
		.exitWhen("0 - Salir")
		.add("1 - Nuevo", CategoriaMain::nuevo)
		.add("2 - Editar", CategoriaMain::editar)
		.loop(); 
		App.getInstance().getConnection().close();
	}
	
	public static void nuevo() throws SQLException {
		Categoria categoria = new Categoria();
		CategoriaConsole.newCategoria(categoria);
		CategoriaDao.save(categoria);
		
	}
	public static void editar() throws SQLException {
		//int id = ScannerHelper.getInt("ID: ");
		long id = CategoriaConsole.getId();
		Categoria categoria = CategoriaDao.load(id);
		if(categoria == null) {
			CategoriaConsole.idNotExists();
			return;
		}
		CategoriaConsole.editCategoria(categoria);
		CategoriaDao.save(categoria);
		
	}
	
	public static void eliminar() throws SQLException {
		long id = CategoriaConsole.getId();
		int filasBorradas = CategoriaDao.delete(id);
			;
	}
	
	public static void consultar() throws SQLException {
		long id = CategoriaConsole.getId();
		Categoria categoria = CategoriaDao.load(id);
		CategoriaConsole.show(categoria);
	}
	public static void listar() throws SQLException {
		List<Categoria>categorias = CategoriaDao.getAll();
		CategoriaConsole.showList(categorias);
	}

}

