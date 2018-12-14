package serpis.ad;

import java.sql.SQLException;
import java.util.List;
import java.util.Scanner;

public class CategoriaConsole {
	public static long getId() {
		return -1;
	}
	public static void newCategoria (Categoria categoria) {
		System.out.println("Dime nombre de nueva categoria");
		Scanner tcl = new Scanner(System.in);
		String nombre = tcl.nextLine();
		categoria.setNombre(nombre);
	}
	public static void editCategoria (Categoria categoria) {
		
	}
	public static void idNotExists () {
		
	}
    public static boolean deleteConfirm () {
    	return false;
		
	}
    public static void show (Categoria categoria) {
		
	}
    public static void showList (List<Categoria> categorias) {
    	for(Categoria categoria : categorias) {
    		System.out.printf("%4s %-20s %n", categoria.getId(),
    				categoria.getNombre());
    	}
		
	}
        
}
