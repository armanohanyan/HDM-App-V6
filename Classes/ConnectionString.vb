Partial Public Class DB

    ''(local)
    Private SQLString As String = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ODB;Data Source=(local)"

    '(remote)
    'Private SQLString As String = "Server=192.168.11.197\ecrserv,55555;Initial Catalog=ODB;User ID=CrmUser;Password=e03ceca7c9e449fea28abb499fd0c556;Persist Security Info=False;Encrypt=True;TrustServerCertificate=True"

    'ODB2 (local)
    'Private SQLString As String = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ODB2;Data Source=(local)"
    '(local from remote)
    'Private SQLString As String = "Server=192.168.11.101; Database=odb; User Id=test; Password=Test200@;"

End Class