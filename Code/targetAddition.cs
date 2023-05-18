public Transform TargetPrefab;
private Transform m_Target;

public override void Initialize() {
    SpawnTarget(TargetPrefab, transform.position);
}

private void SpawnTarget(Transform prefab, Vector3 pos) {
    m_Target = Instantiate(prefab, pos, Quaternion.identity, transform.parent);
}