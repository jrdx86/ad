import java.time.LocalDateTime;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;




public class PedidoMain {

	public static void main(String[] args) {
EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.hmysql");
		
		//Entitymanager es un agente que nos permite realizar operaciones en la bd
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		Articulo articulo = entityManager.find(Articulo.class, 1L);
		show(articulo);
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
		entityManagerFactory.close(); 
		
	}
	private static void show(Articulo articulo) {
		System.out.printf("%4s %-30s %-30s %s %n", articulo.getId(), articulo.getNombre(), articulo.getCategoria(),articulo.getPrecio());
	}

}
