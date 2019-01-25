package serpis.ad;

import java.math.BigDecimal;
import java.util.Scanner;

public class ScannerHelper {
	
	private static Scanner scanner = new Scanner(System.in);
	
	public static int getInt(String label) {
		while(true) {			
		System.out.println(label);
		String inString = scanner.nextLine();
		
		try {
			return Integer.parseInt(inString);
		}catch(NumberFormatException ex) {
			System.out.println("Formato inválido. Vuelve a introducir");
		}
		}
	}
	public static BigDecimal getBigDecimal(String label) {
		while(true) {			
		System.out.println(label);
		String bigDecimalString = scanner.nextLine();
		
		try {
			return new BigDecimal(bigDecimalString);
		}catch(NumberFormatException ex) {
			System.out.println("Formato inválido. Vuelve a introducir");
		}
		}
	}
//	public static String getString (String st) {
//		
//	}
}
