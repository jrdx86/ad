package serpis.ad;


import java.util.List;

import javax.persistence.Entity;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class Hibernate {

	public static void main(String[] args) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.hmysql");
		
		//Entitymanager es un agente que nos permite realizar operaciones en la bd
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		List<Categoria> categorias = entityManager.createQuery("from Categoria",Categoria.class).getResultList();
		
		for(Categoria categoria : categorias) {
			System.out.printf("%3d %s%n", categoria.getId(),categoria.getNombre());
		}
		entityManager.getTransaction().commit();
		entityManager.close();
		
		entityManagerFactory.close();
		
		
		
		

	}

}
