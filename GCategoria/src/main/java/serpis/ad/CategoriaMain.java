package serpis.ad;

import java.util.List;
import java.util.Scanner;
import java.util.ArrayList;

public class CategoriaMain {
	
	
    private static boolean exit = false;
	public static void main(String[] args) {
		Menu.create("Menú Categoría")
		.exitWhen("0 - Salir")
		.add("1 - Nuevo", CategoriaMain::nuevo)
		.add("2 - Editar", CategoriaMain::editar)
		.loop(); 
	}
	
	public static void nuevo() {
		System.out.println("Metodo nuevo");
		
	}
	public static void editar() {
		System.out.println("Metodo editar");
		int id = ScannerHelper.getInt("ID: ");
		
	}

	

}

